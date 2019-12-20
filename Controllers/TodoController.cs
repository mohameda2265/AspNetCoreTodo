using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTodo.Controllers {
    public class TodoController : Controller {

        FakeTodoItemService fake = new FakeTodoItemService ();
        RealTodoItemService real = new RealTodoItemService ();

        private readonly ITodoItemService _todoItemService;
        public TodoController (ITodoItemService todoItemService) {
            _todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index () {
            //var items = await _todoItemService.GetIncompleteItemsAsync ();
            var fakee = await fake.GetIncompleteItemsAsync();
            var reall = await real.GetIncompleteItemsAsync();
            var model = new TodoViewModel () {
                Items = reall
            };
            return View (model);
        }
    }
}