using System;
using Nancy.Responses;
using Nancy.ModelBinding;
using Nancy;
using CraigToDoList.Model;
using CraigToDoList.Repository;
namespace CraigToDoList
{
    /// <summary>
    /// Defines the routes used by the application.
    /// </summary>
    public class ToDoListApiModule : NancyModule
    {

        private IToDoRepository repo;

        public ToDoListApiModule(IToDoRepository repo /* injected by TinyIoC */)
        {
            this.repo = repo;

       
            CreateRoutes();
        }

        private void CreateRoutes()
        {
            ApiHelpRoute();
            GetAllToDoListsRoute();
            GetToDoListRoute();
            CreateListRoute();
            AddItemRoute();
            MarkItemCompletedRoute();
        }

        private void ApiHelpRoute()
        {
            Get["/"] = parameters => "ToDoList API!";
        }

        private void GetAllToDoListsRoute()
        {
            Get["/todolists"] = parameters =>
            {
                return Response.AsJson(repo.AllLists());
            };
        }

        private void GetToDoListRoute()
        {
            Get["/todolist/{id}"] = parameters =>
            {
                ToDoList foundList = repo.GetList(parameters.id);

                try
                {
                    return new JsonResponse(foundList, new DefaultJsonSerializer());
                }
                catch (ToDoListNotFoundException n)
                {
                    Console.WriteLine(n);
                    return NotFound();
                }
            };
        }

        private void CreateListRoute()
        {
            Post["/todolist"] = parameters =>
            {

                ToDoList todoList = this.Bind<ToDoList>();
                repo.CreateList(todoList);

                return Accepted();
            };

        }

        private void MarkItemCompletedRoute()
        {
            Put["/todolist/{listId}/item/{itemId}"] = parameters =>
            {
                try
                {
                    repo.MarkItemCompleted(parameters.listId, parameters.itemId);
                    return Accepted();
                }
                catch (ToDoListNotFoundException e)
                {
                    Console.WriteLine(e);
                    return NotFound();
                }
                catch (ToDoItemNotFoundException e)
                {
                    Console.WriteLine(e);
                    return NotFound();
                }
            };
        }

        private void AddItemRoute()
        {
            Post["/todolist/{listId}/item"] = parameters =>
            {
                ToDoItem item = this.Bind<ToDoItem>();
                try
                {
                    repo.AddItemToList(parameters.listId, item);
                    return Accepted();
                }
                catch (ToDoListNotFoundException n)
                {
                    Console.WriteLine(n);
                    return NotFound();
                }
            };
        }

        private Response Accepted()
        {
            Response response = new Response();
            response.StatusCode = HttpStatusCode.Accepted;
            return response;
        }

        private Response NotFound()
        {
            Response response = new Response();
            response.StatusCode = HttpStatusCode.NotFound;
            return response;
        }
    }

}