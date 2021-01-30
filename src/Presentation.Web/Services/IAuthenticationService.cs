using Repository.Entities;
using System.Web;

namespace Presentation.Web.Services
{
    public interface IAuthenticationService
    {
        void Authenticate(User user, HttpResponseBase response);
        void SignOut();
    }
}
