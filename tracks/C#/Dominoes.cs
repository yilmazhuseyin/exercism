using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
  public static bool CanChain(IEnumerable<(int, int)> dominoes)
  {
      if (dominoes.Count() == 0) return true; 

      foreach ((int, int) item in dominoes)
      {
          List<(int, int)> dominoesList = new List<(int, int)>(dominoes);

            dominoesList.Remove(item);

          if (IsChain(dominoesList, item.Item2, item.Item1)) return true; 
          if (IsChain(dominoesList, item.Item1, item.Item2)) return true; 
      }

      return false;
  }

  public static bool IsChain(List<(int, int)> dominoes, int bind, int first)
  {
      if (dominoes.Count < 1) return bind == first; 
      
      List<(int, int)> connectable = dominoes.Where(d => d.Item1 == bind || d.Item2 == bind).ToList();

      foreach ((int, int) d in connectable)
      {
          dominoes.Remove(d);
          
          if (IsChain(dominoes, (d.Item1 == bind) ? d.Item2 : d.Item1, first)) return true;

          dominoes.Add(d);
      }
    
      return false;
  }
}
