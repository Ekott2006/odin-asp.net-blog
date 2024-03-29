using System.ComponentModel.DataAnnotations;

namespace WebApp.Model;

public class Article
{
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required, MinLength(10)]
    public string Body { get; set; }

    public List<Comment> Comments { get; set; } = [];
}