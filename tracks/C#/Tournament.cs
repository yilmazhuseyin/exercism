using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public static class Tournament
{
    private static string main = $"{"Team",-30} |{"MP",3} |{"W",3} |{"D",3} |{"L",3} |{"P",3}";

    class Team
    {
        public string name;
        public int wonMatches;
        public int tiedMatches;
        public int lostMatches;
        public int playedMatches => wonMatches + lostMatches + tiedMatches;
        public int points => (wonMatches * 3) + (tiedMatches * 1);
        public override string ToString() => $"\n{name,-30} |{playedMatches,3} |{wonMatches,3} |{tiedMatches,3} |{lostMatches,3} |{points,3}";
    }
    public static void Tally(Stream inStream, Stream outStream)
    {
        List<Team> teams = new List<Team>();
        StreamReader reader = new StreamReader(inStream);
        while (!reader.EndOfStream)
        {
            var data = reader.ReadLine().Split(';');
            Team t1 = teams.FirstOrDefault(team => team.name == data[0]) ?? new Team { name = data[0] };
            Team t2 = teams.FirstOrDefault(team => team.name == data[1]) ?? new Team { name = data[1] };
            if (t1.name == "") t1.name = data[0];
            if (t2.name == "") t2.name = data[1];

            switch (data[2])
            {
                case "win":  t1.wonMatches++;  t2.lostMatches++; break;
                case "loss": t1.lostMatches++; t2.wonMatches++;  break;
                default: case "draw": t1.tiedMatches++; t2.tiedMatches++; break;
            }

            if (!teams.Contains(t1)) teams.Add(t1);
            if (!teams.Contains(t2)) teams.Add(t2);
        }

        StringBuilder newString = new StringBuilder();

        foreach (Team team in teams.OrderByDescending(t => t.points).ThenBy(t => t.name)) newString.Append(team);

        outStream.Write(Encoding.ASCII.GetBytes(main + newString));
        outStream.Close();
        inStream.Close();
    }
}
