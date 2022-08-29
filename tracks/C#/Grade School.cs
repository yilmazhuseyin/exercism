using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private Dictionary<string, int> students = new Dictionary<string, int> { };
    
    public void Add(string student, int grade) => students.Add(student, grade);

    public IEnumerable<string> Roster() => students.OrderBy(i => i.Value + i.Key).Select(i => i.Key);
    
    public IEnumerable<string> Grade(int grade) => students.Where(s => s.Value == grade).Select(s => s.Key).OrderBy(s => s);
}
