using System;
using System.Collections.Generic;

namespace CraigToDoList.Model
{

    /// <summary>
    /// A ToDoList belonging to a User.
    /// </summary>
    public class ToDoList : IEntity
    {
        private Dictionary<int, ToDoItem> items = new Dictionary<int, ToDoItem>();

        public ToDoList()
        {

        }

        public ToDoList(int id, String userName, String listName, List<ToDoItem> todos)
        {
            this.Id = id;
            this.UserName = userName;
            this.ToDoListName = listName;
            todos.ForEach(item => AddItem(item));
        }
        
        public int Id { get; set; }

        public String UserName { get; set; }

        public String ToDoListName { get; set;  }

        public void AddItem(ToDoItem newItem)
        {
            if (items.ContainsKey(newItem.Id))
            {
                items.Remove(newItem.Id);
            }
            items.Add(newItem.Id, newItem);
        }

        public List<ToDoItem> Items
        {
            get
            {
                List<ToDoItem> listItems = new List<ToDoItem>(this.items.Values);
                listItems.Sort(new EntityComparer());
                return listItems;
            }
        }
  

        public bool ContainsItem(int itemId)
        {
            return items.ContainsKey(itemId);
        }

        public ToDoItem GetItem(int itemId)
        {
            return items[itemId];
        }

    }
}