using AutoMapper;
using TheBankProject.Entities;
using TheBankProject.Models;

namespace TheBankProject
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<Account, AccountDto>();

            CreateMap<Transaction, TransactionDto>();

            CreateMap<AddUserDto, User>();
            CreateMap<AddAccountDto, Account>();
            CreateMap<TransferDto, Transaction>();
        }
    }
}
