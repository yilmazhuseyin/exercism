using System;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        if ((white.Column == black.Column || white.Row == black.Row) || (white.Column + white.Row == black.Column + black.Row) || (white.Column - white.Row == black.Column - black.Row)) return true;
        else return false;
    }

   public static Queen Create(int row, int column) => row is >= 0 and < 8 && column is >= 0 and < 8 ? new Queen(row, column) : throw new ArgumentOutOfRangeException();
}
