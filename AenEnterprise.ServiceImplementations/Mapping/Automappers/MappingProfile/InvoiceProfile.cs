using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.ServiceImplementations.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers.MappingProfile
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            // Mapping for Invoice to InvoiceView
            CreateMap<Invoice, InvoiceView>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.SalesOrder.Customer.Name));

            // Mapping for InvoiceItem to InvoiceItemView
            CreateMap<InvoiceItem, InvoiceItemView>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.OrderItem.Product.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.OrderItem.Price))
                .ForMember(dest => dest.InvoiceQuantity, opt => opt.MapFrom(src => src.InvoiceQuantity))
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.OrderItem.Unit.Name))
                .ForMember(dest => dest.InvoiceAmount, opt => opt.MapFrom(src => src.InvoiceAmount))
                .ForMember(dest => dest.BalanceQuantity, opt => opt.MapFrom(src => src.BalanceQuantity))
                // Add any other necessary mappings for InvoiceItemView properties.
                ;
        }
    }

}
