using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Data.Models
{
    [Comment("Articles posted on my blog")]
    public class Post
    {
        public Post(string title, string content, string author) 
        {
            Title = title;
            Content = content;
            Author = author;
        }

        [Key]
        [Comment("Record identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Comment("Article title")]
        public string Title { get; set; } = null!;

        [Required]
        [Comment("Article Content")]
        public string Content { get; set; } = null!;

        [Required]
        [MaxLength(150)]
        [Comment("Article author")]
        public string Author { get; set; } = null!;
    }
}
