using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LinqMovieExercise.Test
{
    [TestClass]
    public class UnitTest1
    {
        private List<Movie> Movies { get; set; }
        private List<Person> People { get; set; }
        private List<Character> Characters { get; set; }

        [TestInitialize]
        public void InitializeTesting()
        {
            this.Movies = new List<Movie>();
            this.People = new List<Person>();
            this.Characters = new List<Character>();

            var silvesterStallone = new Person
            {
                Id = 1,
                Name = "Silvester Stallone",
                Age = 55,
                City = "New York",
                Characters = new List<Character>()
            };

            var leoDiCaprio = new Person
            {
                Id = 2,
                Name = "Leonardo Di Caprio",
                Age = 45,
                City = "Los Angeles",
                Characters = new List<Character>()
            };

            var apollo = new Person
            {
                Id = 3,
                Name = "Apollo Real Name",
                Age = 60,
                City = "Los Angeles",
                Characters = new List<Character>()
            };

            var rocky1 = new Movie
            {
                Id = 1,
                Director = leoDiCaprio,
                Name = "Rocky 1",
                Characters = new List<Character>()
            };

            var rocky2 = new Movie
            {
                Id = 2,
                Director = silvesterStallone,
                Name = "Rocky 2",
                Characters = new List<Character>()
            };

            var rockyCharacter = new Character
            {
                Id = 1,
                Movie = rocky1,
                Person = silvesterStallone,
                Name = "Rocky Balboa"
            };

            var rockyCharacterInRocky2 = new Character
            {
                Id = 2,
                Movie = rocky2,
                Person = silvesterStallone,
                Name = "Rocky Balboa"
            };

            var apolloCharacter = new Character
            {
                Id = 3,
                Movie = rocky1,
                Person = apollo,
                Name = "Apollo Creed"
            };

            var apolloCharacterInRocky2 = new Character
            {
                Id = 4,
                Movie = rocky2,
                Person = apollo,
                Name = "Apollo Creed"
            };

            rocky1.Characters.Add(apolloCharacter);
            rocky1.Characters.Add(rockyCharacter);

            rocky2.Characters.Add(apolloCharacter);
            rocky2.Characters.Add(rockyCharacter);

            silvesterStallone.Characters.Add(rockyCharacter);
            silvesterStallone.Characters.Add(rockyCharacterInRocky2);

            apollo.Characters.Add(apolloCharacter);
            apollo.Characters.Add(apolloCharacterInRocky2);

            this.Characters.Add(rockyCharacter);
            this.Characters.Add(rockyCharacterInRocky2);
            this.Characters.Add(apolloCharacter);
            this.Characters.Add(apolloCharacterInRocky2);

            this.Movies.Add(rocky1);
            this.Movies.Add(rocky2);

            this.People.Add(silvesterStallone);
            this.People.Add(apollo);
            this.People.Add(leoDiCaprio);
        }

        [TestMethod]
        public void GetPersonsThatLiveInLosAngeles_Test()
        {
            var query = from p in this.People
                        where p.City == "Los Angeles"
                        select new { p.Name, p.Age, p.City };

            var result = query.ToList();

            Assert.AreEqual(2, result.Count);
        }
        
        [TestMethod]
        public void GetCharactersThatHasBeenPresentOnRocky2_Test()
        {
            var query = from m in this.Movies
                        join c in Characters on m.Id equals c.Movie.Id
                        where m.Name == "Rocky 2"
                        select new { c.Id, c.Name };

            var result = query.ToList();

            Assert.AreEqual(2, query.ToList().Count);

        }
    }
}
