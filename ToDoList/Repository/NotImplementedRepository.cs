using System;
using System.Collections.Generic;
using CraigToDoList.Model;

namespace CraigToDoList.Repository
{
    /// <summary>
    /// To demonstrate coding to an interface and 
    /// choosing an implementation using
    /// Dependency Injection at runtime.
    /// </summary>
    public class NotImplementedRepository : IToDoRepository
    {
        public void AddItemToList(int listId, ToDoItem item)
        {
            throw new NotImplementedException();
        }

        public List<ToDoList> AllLists()
        {
            throw new NotImplementedException();
        }

        public void CreateList(ToDoList todoList)
        {
            throw new NotImplementedException();
        }

        public ToDoList GetList(int listId)
        {
            throw new NotImplementedException();
        }

        public void MarkItemCompleted(int listId, int itemId)
        {
            throw new NotImplementedException();
        }
    }
}