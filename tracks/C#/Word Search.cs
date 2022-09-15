using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private readonly string[] _grid;

    int rowLength;
    int colLength;

    private static int[] x = { -1, -1, -1, 0, 0, 1, 1, 1 };
    private static int[] y = { -1, 0, 1, -1, 1, -1, 0, 1 };

    public WordSearch(string grid)
    {
        _grid = grid.Split('\n');
        rowLength = _grid.Length;
        colLength = _grid[0].Length;
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        var searchDic = new Dictionary<string, ((int, int), (int, int))?>();

        for (int i = 0; i < wordsToSearchFor.Length; i++)
        {
            var word = wordsToSearchFor[i];
            int wordLength = word.Length;

            for (int row = 0; row < rowLength; row++)
            {
                for (int column = 0; column < colLength; column++)
                {
                    if (_grid[row][column] == word[0])
                    {
                        for (int k = 0; k < x.Length; k++)
                        {
                            int res = 1;
                            int rowTurn = row + x[k];
                            int columnTurn = column + y[k];
                          
                            for (; res < wordLength; res++)
                            {
                                if (rowTurn >= rowLength || columnTurn >= colLength || rowTurn < 0 || columnTurn < 0) break;
                                if (_grid[rowTurn][columnTurn] != word[res]) break;
                                rowTurn += x[k];
                                columnTurn += y[k];
                            }

                            if (res == wordLength)
                            {
                                if (rowTurn >= rowLength) SearchDicItem(searchDic, word, column, row, columnTurn, 1, rowTurn);
                                else if (x[k] == -1 && y[k] == 0) SearchDicItem(searchDic, word, column, row, columnTurn, 1, rowTurn,2);
                                else if (x[k] == 1 && y[k] == 1) SearchDicItem(searchDic, word, column, row, columnTurn, 0, rowTurn);
                                else if (x[k] == -1 && y[k] == -1) SearchDicItem(searchDic, word, column, row, columnTurn, 2, rowTurn,2);
                                else if (x[k] == -1 && y[k] == +1) SearchDicItem(searchDic, word, column, row, columnTurn, 0, rowTurn,2);
                                else if (x[k] == +1 && y[k] == -1) SearchDicItem(searchDic, word, column, row, columnTurn, 2, rowTurn);
                                else SearchDicItem(searchDic, word, column, row, columnTurn, 0, rowTurn,1);
                                break;
                            }
                        }
                    }
                }
            }

            if (!searchDic.ContainsKey(word)) searchDic.Add(word, null);
        }
        return searchDic;
    }

    public void SearchDicItem(Dictionary<string, ((int, int), (int, int))?> dictionary, string word, int column, int row, int columnTurn, int columtTurnPlus, int rowTurn, int rowTurnPlus = 0)
    {
        dictionary.Add(word, ((column + 1, row + 1), (Math.Abs(columnTurn) + columtTurnPlus, rowTurn + rowTurnPlus)));
    }
}
