using System;

namespace CraigToDoList.Repository
{
    /// <summary>
    /// Throw if an item cannot be found (when searching by id).
    /// </summary>
    public class ToDoItemNotFoundException: Exception
    {
        public ToDoItemNotFoundException()
        {
        }

        public ToDoItemNotFoundException(string message): base(message)
        {
        }

        public ToDoItemNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }

}