using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private readonly List<int> _list;
    
    public HighScores(List<int> list) => _list = list;
    
    public List<int> Scores() => _list;

    public int Latest() => _list[_list.Count - 1];

    public int PersonalBest() => _list.Max();

    public List<int> PersonalTopThree() => _list.OrderByDescending(x=>x).Take(3).ToList();
}
