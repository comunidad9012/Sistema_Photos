using ApplicationServices.Filters;
using Ardalis.Specification;
using DomainClass.Entity;


namespace ApplicationServices.Specifications
{
    internal class PaginatedPhotoSpecification : Specification<Photo>
    {
        public PaginatedPhotoSpecification(PhotoResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!String.IsNullOrEmpty(filter.Name))
                Query.Search(x => x.Name, "%" + filter.Name + "%");

            if (!String.IsNullOrEmpty(filter.Type))
                Query.Search(x => x.Type, "%" + filter.Type + "%");

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
