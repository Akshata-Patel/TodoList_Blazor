using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList_BlazorServer.Enum;
using ToDoList_BlazorServer.Models;

namespace ToDoList_BlazorServer.Pages.ToDos
{
    public partial class ToDoList
    {
        public ToDo ToDo { get; set; } = new ToDo
        {
            Status = StatusEnum.Create,
            DeadLine = DateTime.Now
        };
        public IList<ToDo> ToDoListItems { get; set; } = new List<ToDo>();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected void HandleValidSubmitAsync()
        {
            if (ToDo.Status == StatusEnum.Create)
            {
                var todo = new ToDo
                {
                    Id = Guid.NewGuid(),
                    Status = ToDo.Status,
                    Description = ToDo.Description,
                    DeadLine = ToDo.DeadLine,
                }; 
                ToDoListItems.Add(todo);
                ToDo.Description = string.Empty;
                ToDo.DeadLine = null;
            }
            else
            {
                ToDoListItems.FirstOrDefault(c => c.Id == ToDo.Id).Description = ToDo.Description;
                ToDoListItems.FirstOrDefault(d => d.Id == ToDo.Id).DeadLine = ToDo.DeadLine;
                ToDo.Description = string.Empty;
                ToDo.DeadLine = null;
            }
        }

        protected void DeleteClick(ToDo toDo)
        {
            ToDoListItems.Remove(toDo);
        }
        protected void CompleteClick(ToDo toDo)
        {
            toDo.IsComplete = !toDo.IsComplete;
        }
        protected void EditClick(ToDo toDo)
        {
            toDo.Status = StatusEnum.Update;
            ToDo.Id = toDo.Id;
            ToDo.Description = toDo.Description;
            ToDo.DeadLine = toDo.DeadLine;
            ToDo.Status = toDo.Status;
        }
    }
}
