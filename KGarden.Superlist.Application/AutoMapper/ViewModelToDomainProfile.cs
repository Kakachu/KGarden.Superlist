using AutoMapper;
using KGarden.Superlist.Application.ViewModels;
using KGarden.Superlist.Domain.Commands.ListItems;
using KGarden.Superlist.Domain.Commands.Lists;
using KGarden.Superlist.Domain.Commands.SuperLists;

namespace KGarden.Superlist.Application.AutoMapper
{
	public class ViewModelToDomainProfile : Profile
	{
		public ViewModelToDomainProfile()
		{
			//SuperLists
			CreateMap<SuperListsViewModel, RegisterSuperListsCommand>()
		   .ConstructUsing(c => new RegisterSuperListsCommand(c.Id, c.Name, c.Identification, c.Email, c.DateCreated, c.DateUpdated));

			CreateMap<SuperListsViewModel, UpdateSuperListsCommand>()
		   .ConstructUsing(c => new UpdateSuperListsCommand(c.Id, c.Name, c.Identification, c.Email, c.DateCreated, c.DateUpdated));

			CreateMap<SuperListsViewModel, RemoveSuperListsCommand>()
		   .ConstructUsing(c => new RemoveSuperListsCommand(c.Id));

			//Lists
			CreateMap<ListsViewModel, RegisterListsCommand>()
		   .ConstructUsing(c => new RegisterListsCommand(c.Id, c.Name, c.Description, c.Identification, c.Email, c.DateCreated, c.DateUpdated, c.SuperListId, c.CategoryId));

			CreateMap<ListsViewModel, UpdateListsCommand>()
		   .ConstructUsing(c => new UpdateListsCommand(c.Id, c.Name, c.Description, c.Identification, c.Email, c.DateCreated, c.DateUpdated, c.SuperListId, c.CategoryId));

			CreateMap<ListsViewModel, RemoveListsCommand>()
		   .ConstructUsing(c => new RemoveListsCommand(c.Id));

			//ListItems
			CreateMap<ListItemsViewModel, RegisterListItemsCommand>()
		   .ConstructUsing(c => new RegisterListItemsCommand(c.Id, c.ProductName, c.PriceUN, c.PriceTotal, c.Amount, c.ProductId, c.ListId));

			CreateMap<ListItemsViewModel, RemoveListItemsCommand>()
		   .ConstructUsing(c => new RemoveListItemsCommand(c.Id));
		}
	}
}
