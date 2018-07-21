﻿using System;
using System.Collections.Generic;

namespace LinqMovieExercise
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person Director { get; set; }
        public List<Character> Characters { get; set; }
    }
}
