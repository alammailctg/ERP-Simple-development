using AenEnterprise.DomainModel.InventoryManagement;
using AenEnterprise.ServiceImplementations.ViewModel.InventoryVM;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers.MappingProfile
{
    public class InventoryMappingProfile:Profile
    {
        public InventoryMappingProfile()
        {
            // Mapping for ProductionOrder to ProductionOrderView
            CreateMap<ProductionOrder, ProductionOrderView>()
                .ForMember(dest => dest.ProductionOrderItems, opt => opt.MapFrom(src => src.ProductionOrderItems))
                .ReverseMap();

            // Mapping for ProductionOrderItem to ProductionOrderItemView
            CreateMap<ProductionOrderItem, ProductionOrderItemView>()
                .ForMember(dest => dest.QuantityRequested, opt => opt.MapFrom(src => src.QuantityRequested))
                .ForMember(dest => dest.QuantityProduced, opt => opt.MapFrom(src => src.QuantityProduced))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ReverseMap();
        }
    }
}
