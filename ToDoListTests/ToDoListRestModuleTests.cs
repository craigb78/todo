using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Testing;
using CraigToDoList.Model;
using CraigToDoList.Repository;
using Xunit;
namespace ToDoListTests
{
    public class ToDoListRestModuleTests
    {
        private Browser browser;

        public ToDoListRestModuleTests()
        {
            ToDoInMemoryRepository inMemoryRepo = new ToDoInMemoryRepository();
            
            browser = new Browser(with => {
                with.Module<CraigToDoList.ToDoListApiModule>();
                with.Dependencies(inMemoryRepo);
            });
        }


        [Fact]
        public void TestGetAllLists()
        {
            const int expectedListId = 123;

            BrowserResponse response = browser.Get("/todolists");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            IEnumerable<ToDoList> toDoLists = response.Body.DeserializeJson<IEnumerable<ToDoList>>();
            Assert.Equal(expectedListId, toDoLists.Single(x => x.ToDoListName == "Weekly shop").Id);
        }

       [Fact]
        public void TestCreateList()
        {
            ToDoList toDoList = new ToDoList(id: 7742,
                userName: "Bill",
                listName: "Things to buy",
                todos: new List<ToDoItem>{
                    new ToDoItem(100, "Paint"),
                    new ToDoItem(200, "Brushes")
                });

            BrowserResponse response = browser.Post("/todolist", with => with.JsonBody(toDoList));
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
        }

        [Fact]
        public void TestAddItemToList()
        {
            ToDoList toDoList = new ToDoList(id: 7742,
                userName: "Bill",
                listName: "Things to buy",
                todos: new List<ToDoItem>{
                    new ToDoItem(100, "Paint"),
                    new ToDoItem(200, "Brushes")
                });

            BrowserResponse response = browser.Post("/todolist", with => with.JsonBody(toDoList));
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            ToDoItem item = new ToDoItem(300, "White spirit");
            browser.Put("/todolist/"+ toDoList.Id + "/item", with => with.JsonBody(item));
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
        }
    }
}
