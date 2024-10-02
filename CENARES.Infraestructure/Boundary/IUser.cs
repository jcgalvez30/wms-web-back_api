using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CENARES.Infraestructure.Entity;

namespace CENARES.Infraestructure.Boundary
{
    internal interface IUser
    {
        int Create(User user, UserMembership member);
        UserModel GetLogin(string username);
    }
}
