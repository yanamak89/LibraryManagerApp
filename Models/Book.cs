using System.ComponentModel.DataAnnotations;
using LibraryManagerApp.Models;

namespace LibraryManagerApp.Models;
public class Book
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Назва є обов'язковою")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Кількість сторінок є обов'язковою")]
    public int Pages { get; set; }

    [Required(ErrorMessage = "Жанр є обов'язковим")]
    public string Genre { get; set; }

    public int AuthorId { get; set; }  // Ідентифікатор автора, до якого прив'язана книга
    public Author Author { get; set; }  // Навігаційна властивість
}