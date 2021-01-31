using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Core.Interface;
using Presentation.Web.Models.Display;
using Presentation.Web.Models.Input;
using Repository.Entities;

namespace Presentation.Web.Controllers
{
    public class TodoListsController : ControllerBase
    {
        protected readonly IUserTaskService _userTaskService;

        public TodoListsController(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        [Authorize]
        public async Task<IEnumerable<TodoListDisplay>> Get()
        {
            int id = 0;
            int.TryParse(User.Identity.Name, out id);

            var todos = await _userTaskService.GetUserTasks(id);


            var displays = todos.Select(x => new TodoListDisplay()
            {
                Name = x.Name,
                Id = x.Id,
                Todos = x.Todos.Select(t => new TodoDisplay() { Id = t.Id, Title = t.Title, Completed = t.Completed, Position = t.Position }).OrderBy(t => t.Position).ToList()
            }).ToList();

            return displays;
        }

        [Authorize]
        [HttpPost]
        public async Task<HttpResponseMessage> Post(TodoListInput list)
        {
            int id = 0;
            int.TryParse(User.Identity.Name, out id);

            await _userTaskService.CreateUserTask(id, list.Name);

            return Request.CreateResponse(HttpStatusCode.OK, new TodoListDisplay() { Name = list.Name, Id = id });
        }

        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(long Id)
        {
            //var list = _repo.Load(Id);
            //_repo.Delete(list);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [Authorize]
        [HttpPost]
        public HttpResponseMessage Todos(long Id, TodoInput todoInput)
        {
            //var list = _repo.Get(Id);
            //var todo = new Todo() { Title = todoInput.Title, Completed = false, Position = list.Todos.Count };
            //list.AddTodo(todo);
            //_repo.Store(list);
            return Request.CreateResponse(HttpStatusCode.OK, new TodoDisplay { /*Title = todoInput.Title, Id = todo.Id, Completed = false, Position = todo.Position */});
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<TodoDisplay> Todos(long Id)
        {

            return null;

            //var list = _repo.Get(Id);
            //return
            //    list.Todos.Select(t => new TodoDisplay() { Id = t.Id, Title = t.Title, Completed = t.Completed, Position = t.Position }).ToList();
            //;
        }
    }
}