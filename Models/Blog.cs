using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Small_API.Models
{
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? EnteranceText { get; set; }
        public string? MainImage { get; set; }
        public string? ExtraImages { get; set; }
        public string? SubTitles { get; set; }
        public string? Paragraphs { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ApproxReadTime { get; set; }
        public string? Tags { get; set; }
    }
}
