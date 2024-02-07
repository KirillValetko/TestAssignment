using AutoMapper;
using TestAssignment.BLL.Models;
using TestAssignment.DAL.DataModels;

namespace TestAssignment.BLL.Infrastructure
{
    public class BllMapperProfiles : Profile
    {
        public BllMapperProfiles()
        {
            CreateMap<AccountDataModel, AccountModel>().ReverseMap();
            CreateMap<AccountClassDataModel, AccountClassModel>().ReverseMap();
            CreateMap<BalanceSheetDataModel, BalanceSheetModel>().ReverseMap();
            CreateMap<BalanceSheetAccountDataModel, BalanceSheetAccountModel>().ReverseMap();
        }
    }
}
