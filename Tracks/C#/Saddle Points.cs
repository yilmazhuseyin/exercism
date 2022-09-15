using System.Collections.Generic;

public static class SaddlePoints
{
  public static IEnumerable<(int, int)> Calculate(int[,] matrix)
  {
      List<(int, int)> result = new();

      int rows = matrix.GetLength(0);
      int columns = matrix.GetLength(1);

      for (int i = 0; i < rows; i++)
      {
          int rowMax = matrix[i, 0];
          var indexList = new List<int> { 0 };

          for (int k = 1; k < columns; k++)
          {
              if (matrix[i, k] > rowMax)
              {
                  rowMax = matrix[i, k];
                  indexList = new List<int> { k };
              }
              else if (matrix[i, k] == rowMax) indexList.Add(k);
          }

          foreach (var item in indexList)
          {
              bool min = true;

              for (int k = 0; k < rows; k++)
              {
                  if (matrix[k, item] < matrix[i, item])
                  {
                      min = false;
                      break;
                  }
              }
              if(min) result.Add((i + 1, item + 1));
          }
      }
      return result;
  }
}
