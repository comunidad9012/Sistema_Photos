using ApplicationServices.Filters;
using Ardalis.Specification;
using DomainClass.Entity;


namespace ApplicationServices.Specifications
{
    internal class PaginatedPhotographerSpecification : Specification<Photographer>
    {
        public PaginatedPhotographerSpecification(PhotographerResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!String.IsNullOrEmpty(filter.Name))
                Query.Search(x => x.Name, "%" + filter.Name + "%");

            if (!String.IsNullOrEmpty(filter.LastName))
                Query.Search(x => x.LastName, "%" + filter.LastName + "%");

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
