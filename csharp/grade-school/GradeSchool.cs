using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly SortedList<string, int> _students = [];

    public bool Add(string student, int grade) => _students.TryAdd(student, grade);
    public IEnumerable<string> Roster() => _students.OrderBy(s => s.Value).Select(s => s.Key);
    public IEnumerable<string> Grade(int grade) => _students.Where(s => s.Value == grade).Select(s => s.Key);
}
