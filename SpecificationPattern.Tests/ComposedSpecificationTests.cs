using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Should;
using Xunit;

namespace SpecificationPattern.Tests {

    public class ComposedSpecificationTests {

        [Fact]
        public void T1() {
            var movie = new Movie("Some Movie", new DateTime(2010, 2, 1), MpaaRating.G, "Triller", 10);
            var pg13Rating = new MpaaRatingAtMostSpecification(MpaaRating.PG13);
            var goodMovie = new GoodMovieSpecification();
            var composed = pg13Rating.And(goodMovie);

            bool isSatisfiedBy = composed.IsSatisfiedBy(movie);

            isSatisfiedBy.ShouldEqual(true);
        }
    }
}
