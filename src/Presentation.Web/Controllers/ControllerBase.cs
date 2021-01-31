using System.Threading.Tasks;
using System.Web.Http;
using Core.Interface;
using Ninject;
using Repository.Entities;

namespace Presentation.Web.Controllers
{
    public class ControllerBase : ApiController
    {
        [Inject]
        public IUserTaskService userTaskService { get; set; }

        protected async Task<User> LoadUser()
        {
            int id = 0;
            int.TryParse(User.Identity.Name, out id);
            return await userTaskService.GetUserById(id);
        }
    }
}