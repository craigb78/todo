using System;

namespace CraigToDoList.Repository
{
    /// <summary>
    /// Throw if a ToDoList cannot be found (when searching by id).
    /// </summary>
    public class ToDoListNotFoundException : Exception
    {
        public ToDoListNotFoundException()
        {
        }

        public ToDoListNotFoundException(string message): base(message)
        {
        }

        public ToDoListNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }

}