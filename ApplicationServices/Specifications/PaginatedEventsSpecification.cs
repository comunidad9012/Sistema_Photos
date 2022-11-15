using ApplicationServices.Filters;
using Ardalis.Specification;
using DomainClass.Entity;


namespace ApplicationServices.Specifications
{
    internal class PaginatedEventsSpecification : Specification<Events>
    {
        public PaginatedEventsSpecification(EventsResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!String.IsNullOrEmpty(filter.Type))
                Query.Search(x => x.Type, "%" + filter.Type + "%");

            if (!String.IsNullOrEmpty(filter.Service))
                Query.Search(x => x.Service, "%" + filter.Service + "%");

            if (filter.IsDeleted == true)
            {
                Query.Where(x => x.IsDeleted == true);
            }
            else
            {
                Query.Where(x => x.IsDeleted == false);
            }

        }
    }
}
