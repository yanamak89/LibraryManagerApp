using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace LibraryManagerApp.Models;

public class Author
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Прізвище є обов'язковим")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Ім'я є обов'язковим")]
    public string FirstName { get; set; }

    
    public string MiddleName { get; set; }

    [Required(ErrorMessage = "Дата народження є обов'язковою")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    public ICollection<Book> Books { get; set; }
}