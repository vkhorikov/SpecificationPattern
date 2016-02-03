using System.Collections.Generic;
using System.Linq;

using NHibernate;
using NHibernate.Linq;


namespace SpecificationPattern
{
    public class MovieRepository : Repository<Movie>
    {
    }


    public abstract class Repository<T>
        where T : Entity
    {
        public IReadOnlyList<T> Find(Specification<T> specification, int page = 0, int pageSize = 100)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<T>()
                    .Where(specification.ToExpression())
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }
    }
}
