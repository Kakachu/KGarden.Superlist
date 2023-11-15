using AutoMapper;
using KGarden.Superlist.Application.ViewModels;
using KGarden.Superlist.Domain.Models;

namespace KGarden.Superlist.Application.AutoMapper
{
	public class DomainToViewModelProfile : Profile
	{
        public DomainToViewModelProfile()
        {
            CreateMap<SuperLists, SuperListsViewModel>();
            CreateMap<Lists, ListsViewModel>();
            CreateMap<ListItems, ListItemsViewModel>();

            CreateMap<Products, ProductsViewModel>();
            CreateMap<Categories, CategoriesViewModel>();
        }
    }
}
