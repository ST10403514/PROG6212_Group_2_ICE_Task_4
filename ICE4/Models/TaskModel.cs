using System;
using System.ComponentModel.DataAnnotations;

namespace ICE4.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string? Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public DateTime Deadline { get; set; }
    }
}
