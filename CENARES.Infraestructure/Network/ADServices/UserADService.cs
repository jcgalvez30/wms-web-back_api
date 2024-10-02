using CENARES.Infraestructure.Boundary;
using CENARES.Infraestructure.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace CENARES.Infraestructure.Network.ADServices
{
    public class UserADService : IUserProvider
    {
        public UserAD CurrentUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Initialized { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        UserAD IUserProvider.CurrentUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task Create(HttpContext context, IConfiguration config)
        {
            CurrentUser = await GetUserAD(context.User.Identity);
            Initialized = true;
        }

        public async Task<List<UserAD>> FindDomainUser(string search)
        {
            return await Task.Run(() =>
            {
                PrincipalContext context = new PrincipalContext(ContextType.Domain);
                UserPrincipal principal = new UserPrincipal(context);
                principal.SamAccountName = $"*{search}*";
                principal.Enabled = true;
                PrincipalSearcher searcher = new PrincipalSearcher(principal);
                //var users = searcher.FindAll().AsQueryable().Cast<UserPrincipal>().FilterUsers().SelectAdUsers().OrderBy(x => x.Surname).ToList();
                var users = searcher.FindAll().Cast<UserPrincipal>()
                .Select(x => new UserAD 
                { 
                    EmployeeId = x.EmployeeId,
                    Name = x.Name,
                    EmailAddress = x.EmailAddress,
                    Enabled = x.Enabled,
                    GivenName = x.GivenName,
                    Surname = x.Surname,
                    SamAccountName = x.SamAccountName,
                    DisplayName= x.DisplayName,
                    Guid = x.Guid,
                    UserPrincipalName = x.UserPrincipalName
                }).OrderBy(x => x.Surname);
                return users.ToList();
            });
        }

        public async Task<List<UserAD>> GetDomainUsers()
        {
            return await Task.Run(() => {
                PrincipalContext context = new PrincipalContext(ContextType.Domain);
                UserPrincipal principal = new UserPrincipal(context);
                principal.UserPrincipalName = "*@*";
                principal.Enabled = true;
                PrincipalSearcher searcher = new PrincipalSearcher(principal);
                //var users = searcher.FindAll().Take(50).AsQueryable().Cast<UserPrincipal>().FilterUsers().SelectAdUsers().OrderBy(x => x.Surname).ToList();
                var users = searcher.FindAll().Take(50).Cast<UserPrincipal>()
                .Select(x => new UserAD
                {
                    EmployeeId = x.EmployeeId,
                    Name = x.Name,
                    EmailAddress = x.EmailAddress,
                    Enabled = x.Enabled,
                    GivenName = x.GivenName,
                    Surname = x.Surname,
                    SamAccountName = x.SamAccountName,
                    DisplayName = x.DisplayName,
                    Guid = x.Guid,
                    UserPrincipalName = x.UserPrincipalName
                }).OrderBy(x => x.Surname);
                return users.ToList();
            });
        }

        public async Task<UserAD> GetUserAD(IIdentity identity)
        {
            return await Task.Run(() => {
                try
                {
                    PrincipalContext context = new PrincipalContext(ContextType.Domain);
                    UserPrincipal principal = new UserPrincipal(context);
                    if (context != null)
                    {
                        principal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, identity.Name);
                    }
                    UserAD userAD = new UserAD();
                    userAD.EmployeeId = principal.EmployeeId;
                    userAD.Name = principal.Name;
                    userAD.EmailAddress = principal.EmailAddress;
                    userAD.Enabled = principal.Enabled;
                    userAD.GivenName = principal.GivenName;
                    userAD.Surname = principal.Surname;
                    userAD.SamAccountName = principal.SamAccountName;
                    userAD.DisplayName = principal.DisplayName;
                    userAD.Guid = principal.Guid;
                    userAD.UserPrincipalName = principal.UserPrincipalName;
                    return userAD;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving User AD", ex);
                }
            });
        }

        public async Task<UserAD> GetUserAD(string samAccountName)
        {
            return await Task.Run(() => {
                try
                {
                    PrincipalContext context = new PrincipalContext(ContextType.Domain);
                    UserPrincipal principal = new UserPrincipal(context);
                    if (context != null)
                    {
                        principal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, samAccountName);
                    }
                    UserAD userAD = new UserAD();
                    userAD.EmployeeId = principal.EmployeeId;
                    userAD.Name = principal.Name;
                    userAD.EmailAddress = principal.EmailAddress;
                    userAD.Enabled = principal.Enabled;
                    userAD.GivenName = principal.GivenName;
                    userAD.Surname = principal.Surname;
                    userAD.SamAccountName = principal.SamAccountName;
                    userAD.DisplayName = principal.DisplayName;
                    userAD.Guid = principal.Guid;
                    userAD.UserPrincipalName = principal.UserPrincipalName;
                    return userAD;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving AD User", ex);
                }
            });
        }

        public async Task<UserAD> GetUserAD(Guid guid)
        {
            return await Task.Run(() => {
                try
                {
                    PrincipalContext context = new PrincipalContext(ContextType.Domain);
                    UserPrincipal principal = new UserPrincipal(context);
                    if (context != null)
                    {
                        principal = UserPrincipal.FindByIdentity(context, IdentityType.Guid, guid.ToString());
                    }
                    UserAD userAD = new UserAD();
                    userAD.EmployeeId = principal.EmployeeId;
                    userAD.Name = principal.Name;
                    userAD.EmailAddress = principal.EmailAddress;
                    userAD.Enabled = principal.Enabled;
                    userAD.GivenName = principal.GivenName;
                    userAD.Surname = principal.Surname;
                    userAD.SamAccountName = principal.SamAccountName;
                    userAD.DisplayName = principal.DisplayName;
                    userAD.Guid = principal.Guid;
                    userAD.UserPrincipalName = principal.UserPrincipalName;
                    return userAD;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving AD User", ex);
                }
            });
        }

        public async Task<UserModel> Login(UserLoginBody settings)
        {
            return await Task.Run(() => {
                try
                {
                    //create a "principal context", for example, your domain (could be machine, too)
                    PrincipalContext context = new PrincipalContext(ContextType.Domain, settings.DomainName, settings.Username, settings.Password);
                    //using (PrincipalContext context = new PrincipalContext(ContextType.Domain, settings.DomainName, settings.Username, settings.Password))
                    //{
                    //validate the credential
                    UserModel oUser = null;
                    bool isValid = context.ValidateCredentials(settings.Username, settings.Password);
                    if (isValid)
                    {
                        UserPrincipal principal = UserPrincipal.FindByIdentity(context,
                                            IdentityType.SamAccountName,
                                            settings.Username);
                        if (principal != null)
                        {
                            oUser = new UserModel(principal.SamAccountName, principal.EmailAddress,
                                principal.Guid.ToString(), principal.Name, principal.Surname, settings.DomainName, false);
                            //principal.Dispose();
                        }
                    }
                    return oUser;
                }
                catch (Exception ex)
                {
                    throw new Exception("Dominio o DNS del Servidor no válido para las credenciales ingresadas: " + ex.Message);
                }
            });
        }

        
    }
}
