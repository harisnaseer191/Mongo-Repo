# Mongo-Repo
NuGet Package in .Net 6
# Mongo-Repo (.Net6)
Add the latest NuGet package of Mongo-Repo. After that in your project, you need to add the MongoDb configuration in your **appsettings.json** file. i.e.
```json
"MongoDbSettings": {
    "ConnectionString": "your-mongodb-connection-string-here",
    "DatabaseName": "your-mongodb-database-name-here"
  },
```
After adding it to your  **appsettings.json** file. You should add these two provided below lines in your **program.cs** file of **.Net6** app.

## Code for Program.cs

    // Adding Mongo-Repo services to the container 
    builder.Services.Configure<AcquireMongoClient>(builder.Configuration.GetSection("MongoDbSettings"));
    builder.Services.AddMongoRepoServices();

## MongoDB Entity 
**Note:** Your MongoDB Entity class must need to inherit **Document** abstract class of Mongo-Repo.

#### Example
    [BsonCollection("people")]
    public class Person : Document
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }

You can also specify your collection name with **BsonCollection Attribute**.

After that you can inject the main Generic Repository Class of this NuGet package which is **IMongoRepository**.

## Usage Example 
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMongoRepository<Person> _peopleRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMongoRepository<Person> peopleRepository)
        {
            _logger = logger;
            _peopleRepository = peopleRepository;
        }
        [HttpPost("registerPerson")]
        public async Task AddPerson(string firstName, string lastName)
        {
            var person = new Person()
            {
                FirstName = "John",
                LastName = "Doe"
            };

            await _peopleRepository.InsertOneAsync(person);
        }  
    }

# NuGet Package Reference
https://www.nuget.org/packages/Mongo-Repo/
