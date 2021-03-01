using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TaskListMVC.Models
{
    public partial class ToDoItems
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Description")]
        public string ItemDescription { get; set; }
        [Required]
        //[Range(typeof(DateTime), DateTime.Today.ToString(), DateTime.Now.AddYears(20).ToString())]
        [DisplayName("Due Date")]
        //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DueDate { get; set; }
        public bool? Progress { get; set; } = false;
        [DisplayName("Employee")]
        [Required]
        public string AssignedEmployee { get; set; }
    }
}
