using FluentNHibernate.Mapping;


namespace SpecificationPattern
{
    public class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
            Map(x => x.ReleaseDate);
            Map(x => x.MpaaRating).CustomType<MpaaRating>();
            Map(x => x.Genre);
            Map(x => x.Rating);
        }
    }
}
