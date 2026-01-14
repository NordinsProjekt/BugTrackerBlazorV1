using System;
using System.ComponentModel.DataAnnotations;

namespace BugTrackerUI
{
    public class Bug
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        [Required]
        [Range(1, 5)]
        public int Priority { get; set; }
        public string Created { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string CreatedBy { get; set; } = "";
    }
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
