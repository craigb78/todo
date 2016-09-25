using System;

namespace CraigToDoList.Model
{
    /// <summary>
    /// an item on a ToDoList.
    /// </summary>
    public class ToDoItem : IEntity
    {
        public ToDoItem()
        {

        }

        public ToDoItem(int id, String description)
        {
            this.Id = id;
            this.Description = description;
            this.Completed = false;
        }

        public int Id { get; set; }
        public bool Completed { get; set; }
        public String Description { get; set; }

    }
}