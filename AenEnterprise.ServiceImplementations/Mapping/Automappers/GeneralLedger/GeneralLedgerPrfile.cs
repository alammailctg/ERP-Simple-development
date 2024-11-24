using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using AenEnterprise.ServiceImplementations.ViewModel.GeneralLedger;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StackExchange.Redis.Role;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers.GeneralLedger
{
    public class GeneralLedgerPrfile : Profile
    {
        public GeneralLedgerPrfile()
        {
            CreateMap<JournalEntry, JournalEntryView>()
             .ForMember(dest => dest.JournalEntryId, opt => opt.MapFrom(src => src.JournalEntryId))
             .ForMember(dest => dest.EntryDate, opt => opt.MapFrom(src => src.EntryDate))
             .ForMember(dest => dest.ReferenceNumber, opt => opt.MapFrom(src => src.ReferenceNumber))
             .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
             .ForMember(dest => dest.JournalEntryLines, opt => opt.MapFrom(src => src.JournalEntryLines));

            CreateMap<JournalEntryLine, JournalEntryLineView>()
                .ForMember(dest => dest.JournalEntryLineId, opt => opt.MapFrom(src => src.JournalEntryLineId))  // Correct property mapping
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountGroupId))
                .ForMember(dest => dest.JournalEntryId, opt => opt.MapFrom(src => src.JournalEntryId))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate));
        }


    }
}
