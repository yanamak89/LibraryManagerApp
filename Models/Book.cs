using System.ComponentModel.DataAnnotations;

namespace LibraryManagerApp.Models;
public class Book
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Назва книги є обов'язковою.")]
    [RegularExpression(@"^[А-Яа-яЁёЇїІіЄєҐґA-Za-z\s]+$", ErrorMessage = "Назва книги може містити тільки літери.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Кількість сторінок є обов'язковою.")]
    [Range(1, int.MaxValue, ErrorMessage = "Кількість сторінок повинна бути більшою за 0.")]
    public int Pages { get; set; }

    [Required(ErrorMessage = "Жанр є обов'язковим.")]
    public string Genre { get; set; }

    public int? AuthorId { get; set; }
    public Author? Author { get; set; }  

}