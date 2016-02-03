using System;


namespace SpecificationPattern
{
    public class Movie : Entity
    {
        public virtual string Name { get; }
        public virtual DateTime ReleaseDate { get; }
        public virtual MpaaRating MpaaRating { get; }
        public virtual string Genre { get; }
        public virtual double Rating { get; }


        protected Movie()
        {
        }


        public Movie(string name, DateTime releaseDate, MpaaRating mpaaRating, string genre, double rating)
            : this()
        {
            Name = name;
            ReleaseDate = releaseDate;
            MpaaRating = mpaaRating;
            Genre = genre;
            Rating = rating;
        }
    }


    public enum MpaaRating
    {
        G = 1,
        PG13 = 2,
        R = 3
    }
}
