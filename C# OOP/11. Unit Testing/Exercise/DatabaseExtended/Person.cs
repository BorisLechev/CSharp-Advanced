namespace ExtendedDatabase
{
    public class Person
    {
        private long id;

        private string username;

        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public string Username
        {
            get { return username; }
            private set { username = value; }
        }

        public long Id
        {
            get { return id; }
            private set { id = value; }
        }
    }
}
