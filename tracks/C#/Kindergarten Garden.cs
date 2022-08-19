using System;
using System.Collections.Generic;

public enum Plant { Violets, Radishes, Clover, Grass }
public class KindergartenGarden
{
    readonly string[] rows;
    readonly string positions = "AABBCCDDEEFFGGHHIIJJKKLL";
    public KindergartenGarden(string diagram) => rows = diagram.Split('\n');
    public IEnumerable<Plant> Plants(string student)
    {
        foreach (string row in rows)
            for (int i = positions.IndexOf(student[0]); i <= positions.IndexOf(student[0]) + 1; i++)
                yield return row[i] == 'V' ? Plant.Violets : row[i] == 'R' ? Plant.Radishes : row[i] == 'C' ? Plant.Clover : Plant.Grass;
    }
}
