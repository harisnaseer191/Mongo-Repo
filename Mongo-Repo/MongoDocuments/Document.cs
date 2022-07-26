using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo_Repo.MongoDocuments
{
    /// <summary>
    /// All MongoDB Entity Classes must Inherit this base class for library usage.
    /// </summary>
    public abstract class Document : IDocument
    {
        public ObjectId Id { get ; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
