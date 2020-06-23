using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Web.Infrastructure.Abstrct
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
