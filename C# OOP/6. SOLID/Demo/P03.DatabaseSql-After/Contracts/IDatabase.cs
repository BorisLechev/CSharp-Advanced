using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DatabaseSql_After.Contracts
{
    public interface IDatabase
    {
        IEnumerable<int> CourseIds();

        IEnumerable<string> CourseNames();

        IEnumerable<string> Search(string substring);

        string GetCourseById(int id);
    }
}
