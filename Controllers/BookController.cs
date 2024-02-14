using BookWorm.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Controllers;

public class BookController : Controller
{
    private readonly IWebHostEnvironment webHostEnvironment;
    private readonly IBook bookrepository;

    public BookController(IWebHostEnvironment webHostEnvironment, BookRepository repository)
    {
        this.webHostEnvironment = webHostEnvironment;
        bookrepository = repository;
    }

    public IActionResult GetAllBooks()
    {
        return View(bookrepository.GetBooks());
    }

    [HttpGet]
    public IActionResult CreateBook()
    {
        return View("CreateBook");
    }
    [HttpGet]
    public IActionResult DetailPage(int bookid)
    {
        var book = bookrepository.GetBook(bookid);
        return View(book);
    }

    [HttpPost]
    public IActionResult CreateBook(BookCreateViewModel bvm)
    {
        Book b = bookrepository.GetBook(bvm.BookId);
        if (b is not null)
        {
            return BadRequest("Book with this Id already exists.");
        }
        else
        {
            string uniqueCFileName = "";
            string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "Image");
            CoverPage covers = new();

            if (bvm.CoverImage == null)
            {
                string fileName = bvm.BookId + "_" + Guid.NewGuid().ToString() + "_" + bvm.CoverImage.FileName;
                uniqueCFileName = Path.Combine(uploadFolder, fileName);
                bvm.CoverImage.CopyTo(new FileStream(uniqueCFileName, FileMode.Create));

                CoverPage coverPage = new()
                {
                    Id = Guid.NewGuid(),
                    url = fileName,
                };
                //covers.Add(coverPage);
            }

            Book book = new Book()
            {
                Id = Guid.NewGuid(),
                BookId = bvm.BookId,
                Title = bvm.Title,
                Description = bvm.Description,
                Price = bvm.Price,
                CoverImage = covers,
            };

            bookrepository.CreateBook(book);
            return RedirectToAction("GetAllBooks");
        }
    }

    [HttpGet]
    public IActionResult DeleteBook(int id)
    {
        var book = bookrepository.GetBook(id);
        if (book is not null)
        {
                var cover = Path.Combine(webHostEnvironment.WebRootPath, "images", book!.CoverImage.url);
                if (System.IO.File.Exists(cover))
                    System.IO.File.Delete(cover);

            bookrepository.DeleteBook(id);
        }
        return RedirectToAction("GetAllBooks");

    }
}
