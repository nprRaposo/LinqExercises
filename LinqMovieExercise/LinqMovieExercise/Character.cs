using System;
using System.Collections.Generic;
using System.Text;

namespace LinqMovieExercise
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person Person { get; set; }
        public Movie Movie { get; set; }
    }
}
