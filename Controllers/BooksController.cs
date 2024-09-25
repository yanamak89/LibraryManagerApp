using LibraryManagerApp.Data;
using LibraryManagerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApp.Controllers;

public class BooksController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<BooksController> _logger; 

    public BooksController(ApplicationDbContext context, ILogger<BooksController> logger)
    {
        _context = context;
        _logger = logger; 
    }
    
    // Виведення списку книг
    public async Task<IActionResult> Index()
    {
        var books = await _context.Books.Include(b => b.Author).ToListAsync();  // Отримуємо всі книги з авторами
        return View(books);  // Передаємо список у представлення
    }

    // Деталі книги
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var book = await _context.Books.Include(b => b.Author)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (book == null) return NotFound();

        return View(book);
    }

    // Створення нової книги (GET)
    public IActionResult Create()
    {
        ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "LastName");
        return View();
    }

// Створення нової книги (POST)
    [HttpPost]
    public async Task<IActionResult> Create(Book book)
    {
        if (ModelState.IsValid)
        {
            _context.Add(book);  
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "LastName", book.AuthorId);
        return View(book);
    }
    
    // Редагування книги (GET)
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var book = await _context.Books.FindAsync(id);
        if (book == null) return NotFound();

        ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "LastName", book.AuthorId);
        return View(book);
    }

    // Редагування книги (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Book book)
    {
        if (id != book.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(book.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "LastName", book.AuthorId);
        return View(book);
    }

    // Видалення книги (GET)
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var book = await _context.Books.Include(b => b.Author)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (book == null) return NotFound();
        return View(book);
    }

    // Підтвердження видалення книги (POST)
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
    
    private bool BookExists(int id)
    {
        return _context.Books.Any(e => e.Id == id);
    }
}