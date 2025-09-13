using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasksManagerMVC.Models
{
    [Table("MVCTasks")]
    public class TaskItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("task_name")]
        public string Description { get; set; } = string.Empty;

        [Column("completed")]
        public int IsCompleted { get; set; }
    }
}