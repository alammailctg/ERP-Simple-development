using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using AenEnterprise.ServiceImplementations.ViewModel;
using AenEnterprise.ServiceImplementations.ViewModel.GeneralLedger;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers
{
    public class SalesOrderProfile : Profile
    {
        public SalesOrderProfile()
        {
            CreateMap<SalesOrder, SalesOrderView>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ForMember(dest => dest.Invoices, opt => opt.MapFrom(src => src.Invoices))
                .ForMember(dest => dest.DeliveryOrders, opt => opt.MapFrom(src => src.DeliveryOrders))
                .ForMember(dest => dest.DispatcheOrders, opt => opt.MapFrom(src => src.DispatcheOrders))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name)) // Adjust this line
                .ReverseMap(); // If reverse mapping is required

            CreateMap<OrderItem, OrderItemView>().ReverseMap();

          
            CreateMap<AccountGroup, AccountView>();
            CreateMap<JournalEntry, JournalEntryView>()
              .ForMember(dest => dest.JournalEntryLines, opt => opt.MapFrom(src => src.JournalEntryLines));
            CreateMap<JournalEntryLine, JournalEntryLineView>();
        }

    }

}
