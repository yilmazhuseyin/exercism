using System;
using System.Collections.Generic;
using System.Linq;

public enum Owner
{
    None, Black, White
}

public class GoCounting
{
    private readonly Owner[][] _input;

    public GoCounting(string input) => _input = ParseBoard(input);
    private static Owner CharToPlayer(char c) => c switch
    {
        'B' => Owner.Black,
        'W' => Owner.White,
        _ => Owner.None
    };
    private static Owner[][] ParseBoard(string input) => input.Split('\n').Select(row => row.Select(CharToPlayer).ToArray()).ToArray();
    
    private int Cols => _input[0].Length;

    private int Rows => _input.Length;

    private bool IsValidCoordinate((int, int) coordinate) => coordinate.Item2 >= 0 && coordinate.Item2 < Rows && coordinate.Item1 >= 0 && coordinate.Item1 < Cols;

    private Owner GetPlayer((int, int) coordinate) => _input[coordinate.Item2][coordinate.Item1];

    private bool IsEmpty((int, int) coordinate) => GetPlayer(coordinate) == Owner.None;

    private bool IsTaken((int, int) coordinate) => !IsEmpty(coordinate);

    private IEnumerable<(int, int)> EmptyCoordinates() => Enumerable.Range(0, Cols).SelectMany(col => Enumerable.Range(0, Rows).Select(row => (col, row))).Where(IsEmpty);
    
    private IEnumerable<(int, int)> NeighborCoordinates((int, int) coordinate)
    {
        var row = coordinate.Item2;
        var col = coordinate.Item1;

        var coords = new[]
        {
            (col,row - 1),
            (col - 1, row),
            (col + 1, row),
            (col, row + 1)
        };

        return coords.Where(IsValidCoordinate);
    }

    private IEnumerable<(int, int)> TakenNeighborCoordinates((int, int) coordinate) => NeighborCoordinates(coordinate).Where(IsTaken);
    private IEnumerable<(int, int)> EmptyNeighborCoordinates((int, int) coordinate) => NeighborCoordinates(coordinate).Where(IsEmpty);

    private Owner TerritoryOwner(IEnumerable<(int, int)> coords)
    {
        var colors = coords.SelectMany(TakenNeighborCoordinates).Select(GetPlayer);

        var unColors = ToSet(colors);

        if (unColors.Count == 1) return unColors.First();

        return Owner.None;
    }

    private HashSet<(int, int)> TerritoryHelper(HashSet<(int, int)> remainder, HashSet<(int, int)> acc)
    {
        if (!remainder.Any()) return acc;

        var empty = new HashSet<(int, int)>(remainder.SelectMany(EmptyNeighborCoordinates));

        empty.ExceptWith(acc);

        var acc2 = ToSet(acc);

        acc2.UnionWith(empty);

        return TerritoryHelper(empty, acc2);
    }
    private HashSet<(int, int)> TerritoryHelper((int, int) coordinate) => IsValidCoordinate(coordinate) && IsEmpty(coordinate) ? TerritoryHelper(ToSingletonSet(coordinate), ToSingletonSet(coordinate)) : new HashSet<(int, int)>();

    public ValueTuple<Owner, IEnumerable<(int, int)>> Territory((int, int) coord)
    {
        if (coord.Item1 < 0 || coord.Item1 >= Rows || coord.Item2 < 0 || coord.Item2 >= Cols) throw new ArgumentException();
     
        if (!TerritoryHelper(coord).Any()) return (Owner.None, Enumerable.Empty<(int, int)>());

        return (TerritoryOwner(TerritoryHelper(coord)), TerritoryHelper(coord).OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToArray());
    }
    private Dictionary<Owner, (int, int)[]> TerritoriesHelper(HashSet<(int, int)> remainder, Dictionary<Owner, (int, int)[]> acc)
    {
        if (!remainder.Any()) return acc;

        var coord = remainder.First();

        var coords = TerritoryHelper(coord);

        var res = TerritoryOwner(coords);

        var newRemainder = ToSet(remainder);

        newRemainder.ExceptWith(coords);

        acc[res] = acc[res].Concat(coords).ToArray();

        return TerritoriesHelper(newRemainder, acc);
    }
    public Dictionary<Owner, (int, int)[]> Territories()
    {
        var emptyCoords = EmptyCoordinates();

        var territories = new Dictionary<Owner, (int, int)[]>
        {
            [Owner.Black] = Array.Empty<(int, int)>(),
            [Owner.White] = Array.Empty<(int, int)>(),
            [Owner.None] = Array.Empty<(int, int)>()
        };

        return TerritoriesHelper(ToSet(emptyCoords), territories);
    }

    private static HashSet<T> ToSet<T>(IEnumerable<T> value) => new HashSet<T>(value);
    private static HashSet<T> ToSingletonSet<T>(T value) => new HashSet<T> { value };
}
