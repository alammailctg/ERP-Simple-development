using AenEnterprise.DomainModel;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using AenEnterprise.DomainModel.SupplyAndChainManagement;
using AenEnterprise.DomainModel.UserDomain;
using AenEnterprise.ServiceImplementations.ViewModel;
using AenEnterprise.ServiceImplementations.ViewModel.AccountsReceivable;
using AenEnterprise.ServiceImplementations.ViewModel.AuthenticationVM;
using AenEnterprise.ServiceImplementations.ViewModel.ProcurementVM;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Category, CategoryView>().ReverseMap();
            CreateMap<Product, ProductView>().ReverseMap();
            CreateMap<Unit, ProductView>().ReverseMap();

            CreateMap<Customer, ProductView>().ReverseMap();
            CreateMap<PaymentReceipt, PaymentReceiptView>().ReverseMap();
          

            CreateMap<Customer, CustomerView>()
            .ReverseMap();

            CreateMap<PurchaseOrder, PurchaseOrderView>().ReverseMap();
            
            CreateMap<PurchaseItem, PurchaseItemView>().ReverseMap()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<Role, RoleView>().ReverseMap();
            CreateMap<User, UserView>().ReverseMap();
            CreateMap<OnlineUser, OnlineUserView>().ReverseMap();

            CreateMap<UserRole, UserRoleView>()
              .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username))
              .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName))
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
              .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role.Id));

          

        }
    }
}
