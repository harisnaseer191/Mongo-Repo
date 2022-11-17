using MongoDB.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo_Repo.Tests.Data
{
    public class MongoRepoClassData : IEnumerable<ExampleTestDocument[]>
    {
        public IEnumerator<ExampleTestDocument[]> GetEnumerator()
        {
            yield return new ExampleTestDocument[] {new ExampleTestDocument(new ObjectId("Id1"),"Haris","Naseer")};
            yield return new ExampleTestDocument[] {new ExampleTestDocument(new ObjectId("Id2"),"Sami","Rashid")};
            yield return new ExampleTestDocument[] {new ExampleTestDocument(new ObjectId("Id3"),"Nashit","Butt")};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
