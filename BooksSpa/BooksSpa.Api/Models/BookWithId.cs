using System.ComponentModel.DataAnnotations.Schema;

namespace BooksSpa.Api.Models;

public class BookWithId: Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}