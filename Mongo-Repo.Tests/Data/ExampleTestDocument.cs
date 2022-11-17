using Mongo_Repo.MongoDocuments;

namespace Mongo_Repo.Tests.Data
{
    public class ExampleTestDocument : Document
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public ExampleTestDocument(Object id,string firstName, string lastName)
        {
            this.Id = Id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = DateTime.Today;
        }
    }
}
