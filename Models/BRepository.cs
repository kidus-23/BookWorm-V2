using Microsoft.EntityFrameworkCore;

namespace BookWorm.Models
{
    public class BRepository : IBook
    {
        private readonly ApplicationDbContext _context;

        public BRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Book> GetBooks()
        {
            return _context.Books.AsNoTracking().Include(p => p.CoverImage).ToList();
        }

        public Book? GetBook(int bookid)
        {
            return _context.Books.FirstOrDefault(book => book.BookId == bookid);
        }

        public void CreateBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int bookid)
        {
            Book b = _context.Books.Where(book => book.BookId == bookid).FirstOrDefault();
            if (b != null)
            {
                _context.Books.Remove(b);
                _context.SaveChanges();
            }
        }
    }

}
