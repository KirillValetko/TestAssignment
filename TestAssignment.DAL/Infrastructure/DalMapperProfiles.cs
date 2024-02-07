using AutoMapper;
using TestAssignment.DAL.DataModels;
using TestAssignment.DAL.Models;

namespace TestAssignment.DAL.Infrastructure
{
    public class DalMapperProfiles : Profile
    {
        public DalMapperProfiles()
        {
            CreateMap<Account, AccountDataModel>().ReverseMap();
            CreateMap<AccountClass, AccountClassDataModel>().ReverseMap();
            CreateMap<BalanceSheet, BalanceSheetDataModel>().ReverseMap();
            CreateMap<BalanceSheetAccount, BalanceSheetAccountDataModel>().ReverseMap();
        }
    }
}
