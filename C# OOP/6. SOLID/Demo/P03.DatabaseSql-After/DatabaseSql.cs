using P03.DatabaseSql_After.Contracts;
using System.Collections.Generic;

namespace P03._Database
{
    public class DatabaseSql : IDatabase
    {
        public IEnumerable<int> CourseIds()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> CourseNames()
        {
            throw new System.NotImplementedException();
        }

        public string GetCourseById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> Search(string substring)
        {
            throw new System.NotImplementedException();
        }
    }
}