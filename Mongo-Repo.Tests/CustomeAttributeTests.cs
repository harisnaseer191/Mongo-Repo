using Mongo_Repo.CustomeAttributes;

namespace Mongo_Repo.Tests
{
    public class CustomeAttributeTests
    {
        [Fact]
        public void Should_CreateBsonCollectionAttribute()
        {
            // Arrange
            string collectionName = "MyCollection";
            var attr = new BsonCollectionAttribute(collectionName);
            // Act


            // Assert
            Assert.Equal(attr.CollectionName, collectionName);
        }
    }
}