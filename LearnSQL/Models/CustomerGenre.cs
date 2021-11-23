using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSQL.Models
{
    public class CustomerGenre
    {
        public CustomerGenre(int genreId, string genreName, int counter )
        {
            GenreId = genreId;
            GenreName = genreName;
            Counter = counter;
        }
        public int GenreId { get; set; }

        public string GenreName { get; set; }

        public int Counter { get; set; }

        public override string ToString()
        {
            return $"{GenreId} | {GenreName} | {Counter}";
        }
    }
}
