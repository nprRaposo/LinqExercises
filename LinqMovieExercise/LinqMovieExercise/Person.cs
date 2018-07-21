using System;
using System.Collections.Generic;
using System.Text;

namespace LinqMovieExercise
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public List<Character> Characters { get; set; }
    }
}
