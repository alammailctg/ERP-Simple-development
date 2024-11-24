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
    public class DeliveryOrderProfile : Profile
    {
        public DeliveryOrderProfile()
        {
            CreateMap<DeliveryOrder, DeliveryOrderView>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.SalesOrder.Customer.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DeliveryOrderItems, opt => opt.MapFrom(src =>
                    src.DeliveryOrderItems != null
                        ? src.DeliveryOrderItems.Select(doi => new DeliveryOrderItemView
                        {
                            Id = doi.Id,
                            ProductName = doi.OrderItem != null && doi.OrderItem.Product != null
                                ? doi.OrderItem.Product.Name
                                : "Unknown", // Handle null OrderItem or Product
                            Price = doi.OrderItem != null
                                ? doi.OrderItem.Price
                                : 0, // Handle null OrderItem
                            DeliveryQuantity = doi.DeliveryQuantity,
                            DeliveryAmount = doi.DeliveryAmount,
                        })
                        : new List<DeliveryOrderItemView>() // Return an empty list if null
                ))
                .ReverseMap();

             CreateMap<DeliveryOrderItem, DeliveryOrderItemView>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.OrderItem.Product.Name)) // Map ProductName from OrderItem.Product.Name
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.OrderItem.Price)) // Map Price from OrderItem.Price
            .ForMember(dest => dest.DeliveryQuantity, opt => opt.MapFrom(src => src.DeliveryQuantity))
            .ForMember(dest => dest.BalanceQuantity, opt => opt.MapFrom(src => src.BalanceQuantity))
            .ForMember(dest => dest.DeliveryAmount, opt => opt.MapFrom(src => src.DeliveryAmount))
            .ForMember(dest => dest.BalanceAmount, opt => opt.MapFrom(src => src.BalanceAmount))
            .ForMember(dest => dest.OrderItemId, opt => opt.MapFrom(src => src.OrderItemId)) // Assuming OrderItemId exists
            .ForMember(dest => dest.DeliveryOrderId, opt => opt.MapFrom(src => src.DeliveryOrderId))
            
            .ReverseMap();
        }
    }


}
