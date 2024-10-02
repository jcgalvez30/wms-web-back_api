using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CENARES.Infraestructure.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CENARES.Infraestructure.Boundary
{
    public interface IUserProvider
    {
        UserAD CurrentUser
        {
            get;
            set;
        }
        bool Initialized
        {
            get;
            set;
        }
        Task Create(HttpContext context, IConfiguration config);
        Task<UserAD> GetUserAD(IIdentity identity);
        Task<UserAD> GetUserAD(string samAccountName);
        Task<UserAD> GetUserAD(Guid guid);
        Task<List<UserAD>> GetDomainUsers();
        Task<List<UserAD>> FindDomainUser(string search);
        Task<UserModel> Login(UserLoginBody settings);
    }
}
