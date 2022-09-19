using System;
using System.Linq;
public class Matrix
{
    private readonly int _rowCount;
    private readonly int _columns;
    private readonly string[] _rows;


    public Matrix(string input)
    {
        _rows = input.Split('\n');
        _rowCount = _rows.Length;
        _columns = _rows[0].Where(x => char.IsDigit(x)).Count();
    }

    public int[] Row(int row)
    {
        var currentRow = _rows[row - 1].Split(' ');

        var result = new int[_columns];

        for (int i = 0; i < currentRow.Length; i++) result[i] = int.Parse(currentRow[i]);
        
        return result;
    }

    public int[] Column(int col)
    {
        var columns = new string[_rowCount][];

        for (int i = 0; i < _rowCount; i++) columns[i] = _rows[i].Split(' ');
        
        int[] result = new int[_rowCount];

        for (int i = 0; i < columns.Length; i++) result[i] = int.Parse(columns[i][col - 1]);
        
        return result;
    }

}
