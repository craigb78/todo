using System;
using System.Collections.Generic;
using CraigToDoList.Model;

namespace CraigToDoList.Repository
{
    /// <summary>
    /// In-memory implementation of repository for testing.
    /// </summary>
    public class ToDoInMemoryRepository : IToDoRepository
    {

        private static Dictionary<int, ToDoList> store = new Dictionary<int, ToDoList>();
        
        static ToDoInMemoryRepository()
        {
            ToDoList suesList = new ToDoList(id: 456,
                userName: "Sue",
                listName: "Things to do on Saturday",
                todos: new List<ToDoItem>{
                    new ToDoItem(100, "Walk dog"),
                    new ToDoItem(200, "Eat breakfast"),
                    new ToDoItem(300, "Make lunch"),
                    new ToDoItem(400, "Buy milk")
                });

            ToDoList bobsList = new ToDoList(id: 123, 
                userName: "Bob", 
                listName: "Weekly shop",                         
                todos: new List<ToDoItem>{
                    new ToDoItem(100, "Biscuits"),
                    new ToDoItem(200, "Crisps"),
                    new ToDoItem(300, "Apples"),
                    new ToDoItem(400, "Oranges")
                });

            store.Add(bobsList.Id, bobsList);
            store.Add(suesList.Id, suesList);
        }

        public static void Clear()
        {
            store.Clear(); 
        }

        public void AddItemToList(int listId, ToDoItem item)
        {
            if (store.ContainsKey(listId))
            {
                ToDoList listToAddTo = store[listId];
                item.Id = listToAddTo.Items.Count;
                listToAddTo.AddItem(item);
            }
            else
            {
                throw new ToDoListNotFoundException(listId + " was not found");
            }
        }

        public List<ToDoList> AllLists()
        {
            List<ToDoList> copy = new List<ToDoList>();
            copy.AddRange(store.Values);
            copy.Sort(new EntityComparer());
            return copy;
        }

        public void CreateList(ToDoList toDoList)
        {
            if (!store.ContainsKey(toDoList.Id))
            {
                store.Add(toDoList.Id, toDoList);
            } 
        }

        public ToDoList GetList(int listId)
        {
            if (store.ContainsKey(listId))
            {
                return store[listId];
            }
            else
            {
                String msg = String.Format("ListId: {0} was not found", listId);
                throw new ToDoListNotFoundException(msg);
            }
        }

        public void MarkItemCompleted(int listId, int itemId)
        {
            if (store.ContainsKey(listId))
            {
                ToDoList toDoList = store[listId];

                if (toDoList.ContainsItem(itemId))
                {

                    ToDoItem itemToComplete = toDoList.GetItem(itemId);
                    itemToComplete.Completed = true;
                }
                else
                {
                    String msg = String.Format("ItemId: {0} not found in listId: {1}", itemId, listId);
                    throw new ToDoItemNotFoundException(msg);
                }
            }
            else
            {
                String msg = String.Format("ListId: {0} was not found", listId);
                throw new ToDoListNotFoundException(msg);
            }
        }
    }
}