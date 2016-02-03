using System;
using System.Linq.Expressions;


namespace SpecificationPattern
{
    public class MpaaRatingAtMostSpecification : Specification<Movie>
    {
        private readonly MpaaRating _rating;


        public MpaaRatingAtMostSpecification(MpaaRating rating)
        {
            _rating = rating;
        }


        public override Expression<Func<Movie, bool>> ToExpression()
        {
            return movie => movie.MpaaRating <= _rating;
        }
    }


    public class GoodMovieSpecification : Specification<Movie>
    {
        private const double Threshold = 7;


        public override Expression<Func<Movie, bool>> ToExpression()
        {
            return movie => movie.Rating >= Threshold;
        }
    }
}
