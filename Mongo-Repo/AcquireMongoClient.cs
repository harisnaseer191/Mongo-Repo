using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo_Repo
{
    public interface IAcquireMongoClient
    {
        /// <summary>
        /// Name of the Mongo Database
        /// </summary>
        public string DatabaseName { get; }
        /// <summary>
        /// Connection String for MongoServer
        /// </summary>
        public string ConnectionString { get; set; }
    }
    public class AcquireMongoClient : IAcquireMongoClient
    {
        public string DatabaseName { get; set;}

        public string ConnectionString {get; set;}

    }
}
