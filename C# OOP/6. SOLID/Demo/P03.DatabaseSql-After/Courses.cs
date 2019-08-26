using P03.DatabaseSql_After.Contracts;

namespace P03._Database
{
    public class Courses
    {
        private readonly IDatabase database;

        public Courses(IDatabase database)
        {
            this.database = database;
        }

        public void PrintAll()
        {
            var courses = database.CourseNames();

            //print courses
        }

        public void PrintIds()
        {
            var courseIds = database.CourseIds();

            //print course ids
        }

        public void PrintById(int id)
        {
            var course = database.GetCourseById(id);

            // print course
        }

        public void Search(string substring)
        {
            var courses = database.Search(substring);

            // print courses
        }
    }
}
