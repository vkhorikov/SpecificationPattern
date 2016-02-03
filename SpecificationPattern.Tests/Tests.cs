using System;
using System.Collections.Generic;

using Should;

using Xunit;


namespace SpecificationPattern.Tests
{
    public class Tests
    {
        [Fact]
        public void T1()
        {
            var gRating = new MpaaRatingAtMostSpecification(MpaaRating.G);
            var repository = new MovieRepository();

            IReadOnlyList<Movie> movies = repository.Find(gRating);

            movies.Count.ShouldEqual(1);
        }


        [Fact]
        public void T1_1()
        {
            var rRating = new MpaaRatingAtMostSpecification(MpaaRating.R);
            var repository = new MovieRepository();

            IReadOnlyList<Movie> movies = repository.Find(rRating);

            movies.Count.ShouldEqual(2);
        }


        [Fact]
        public void T2()
        {
            var movie = new Movie("Some Movie", new DateTime(2010, 2, 1), MpaaRating.R, "Triller", 7);
            var pg13Rating = new MpaaRatingAtMostSpecification(MpaaRating.PG13);

            bool isSatisfiedBy = pg13Rating.IsSatisfiedBy(movie);

            isSatisfiedBy.ShouldEqual(false);
        }


        [Fact]
        public void T3()
        {
            var movie = new Movie("Some Movie", new DateTime(2010, 2, 1), MpaaRating.G, "Triller", 7);
            var pg13Rating = new MpaaRatingAtMostSpecification(MpaaRating.PG13);

            bool isSatisfiedBy = pg13Rating.IsSatisfiedBy(movie);

            isSatisfiedBy.ShouldEqual(true);
        }


        [Fact]
        public void T4()
        {
            var gRating = new MpaaRatingAtMostSpecification(MpaaRating.G);
            var goodMovie = new GoodMovieSpecification();
            var repository = new MovieRepository();

            IReadOnlyList<Movie> movies = repository.Find(gRating.And(goodMovie));

            movies.Count.ShouldEqual(0);
        }


        [Fact]
        public void T5()
        {
            var gRating = new MpaaRatingAtMostSpecification(MpaaRating.G);
            var goodMovie = new GoodMovieSpecification();
            var repository = new MovieRepository();

            IReadOnlyList<Movie> movies = repository.Find(gRating.Or(goodMovie));

            movies.Count.ShouldEqual(2);
        }
    }
}
