using ApplicationServices.Filters;
using Ardalis.Specification;
using DomainClass.Entity;


namespace ApplicationServices.Specifications
{
    internal class PaginatedClientSpecification : Specification<Client>
    {
        public PaginatedClientSpecification(ClientResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!String.IsNullOrEmpty(filter.NameClient))
                Query.Search(x => x.NameClient, "%" + filter.NameClient + "%");

            if (!String.IsNullOrEmpty(filter.NameLastClient))
                Query.Search(x => x.NameLastClient, "%" + filter.NameLastClient + "%");

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
