using Mongo_Repo.MongoDocuments;
using Mongo_Repo.Repository;
using Mongo_Repo.Tests.Data;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo_Repo.Tests
{
    public class MongoRepositoryTests
    {
        private readonly Mock<IAcquireMongoClient> _client = new Mock<IAcquireMongoClient>();
        private readonly Mock<IMongoCollection<IDocument>> _collection = new Mock<IMongoCollection<IDocument>>();
        private Mock<IMongoDatabase> _mockDB;

        private Mock<MongoClient> _mockClient;

        private  IMongoRepository<IDocument> _sut;
        public MongoRepositoryTests()
        {
            _mockDB = new Mock<IMongoDatabase>();
            _mockClient = new Mock<MongoClient>("mongodb://tes123");
        }
        
        [Fact]
        public void Should_CreateRepositoryObject()
        {
            // Arrange
            var settings = new AcquireMongoClient()
            {
                ConnectionString = "mongodb://tes123",
                DatabaseName = "Test"
            };

            _client.SetupGet(c => c.ConnectionString).Returns(settings.ConnectionString);
            _client.SetupGet(c => c.DatabaseName).Returns(settings.DatabaseName);
            _mockClient.Setup(c => c
                .GetDatabase(settings.DatabaseName, null))
                .Returns(_mockDB.Object);

            // Act
            _sut = new MongoRepository<IDocument>(_client.Object,_collection.Object);




            //Assert
            Assert.NotNull(_sut);
        }
        [Fact]
        public void Should_InsertOneDocument()
        {
            // Arrange
            // Arrange
            var settings = new AcquireMongoClient()
            {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "Test"
            };
            var testDoc = new ExampleTestDocument("786", "ALi", "Khc");

            _client.SetupGet(c => c.ConnectionString).Returns(settings.ConnectionString);
            _client.SetupGet(c => c.DatabaseName).Returns(settings.DatabaseName);

            _mockClient.Setup(c => c
                .GetDatabase(settings.DatabaseName, null))
                .Returns(_mockDB.Object);
            _mockDB.Setup(c => c.GetCollection<IDocument>(typeof(ExampleTestDocument).Name, null)).Returns(_collection.Object);
            _collection.Setup(c => c.InsertOne(It.IsAny<IDocument>(), null, default(CancellationToken)));

            // Act
            _sut = new MongoRepository<IDocument>(_client.Object,_collection.Object);
            _sut.InsertOne(testDoc);

            //Assert
            _collection.Verify(c => c.InsertOne(testDoc, null, default(CancellationToken)), Times.Once);

        }
    }
}
