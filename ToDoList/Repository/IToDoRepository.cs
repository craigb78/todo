using System;
using CraigToDoList.Model;
using System.Collections.Generic;

namespace CraigToDoList
{
    /// <summary>
    /// Store for ToDoLists and associated items.
    /// </summary>
    public interface IToDoRepository
    {
        void CreateList(ToDoList todoList);
        
        void AddItemToList(int listId, ToDoItem item);

        /// <summary>
        /// Mark item on list as complete
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="itemId"></param>
        void MarkItemCompleted(int listId, int itemId);

        List<ToDoList> AllLists();

        ToDoList GetList(int listId);
    }
}
