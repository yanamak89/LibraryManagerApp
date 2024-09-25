using System.ComponentModel.DataAnnotations;

namespace LibraryManagerApp.Models;

public class Author
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Фамілія є обовʼязковою.")]
    [RegularExpression(@"^[А-Яа-яЁёЇїІіЄєҐґA-Za-z]+$", ErrorMessage = "Фамілія може містити тільки літери.")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Імʼя є обовʼязковим.")]
    [RegularExpression(@"^[А-Яа-яЁёЇїІіЄєҐґA-Za-z]+$", ErrorMessage = "Імʼя може містити тільки літери.")]
    public string FirstName { get; set; }
    
    [RegularExpression(@"^[А-Яа-яЁёЇїІіЄєҐґA-Za-z]+$", ErrorMessage = "По-батькові може містити тільки літери.")]
    public string? MiddleName { get; set; }
    
    [Required(ErrorMessage = "Дата народження є обовʼязковою.")]
    public DateTime DateOfBirth { get; set; }
    public ICollection<Book> Books { get; set; } = [];  // Ініціалізація порожнім списком
    
}