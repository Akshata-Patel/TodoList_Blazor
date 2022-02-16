using System;
using System.ComponentModel.DataAnnotations;
using ToDoList_BlazorServer.Enum;

namespace ToDoList_BlazorServer.Models
{
    public class ToDo
    {
        public Guid Id { get; set; }
        [Required]
        public bool IsComplete { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
        [Required]
        public DateTime? DeadLine { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
    }
}
