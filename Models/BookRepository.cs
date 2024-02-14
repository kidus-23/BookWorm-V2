namespace BookWorm.Models
{
    public class BookRepository : IBook
    {
        private static List<Book> Books = new();
        public List<Book> GetBooks()
        {
            return Books;
        }

        public Book GetBook(int id)
        {
            var index = Books.FindIndex(book => book.BookId == id);

            if (index >= 0 && index < Books.Count)
            {
                return Books[index];
            }
            else
            {
                return null;
            }
        }
        public void CreateBook(Book book) 
        {
            Books.Add(book);
        }
        public void UpdateBook(Book book)
        {
            var b = Books.FindIndex(book => book.BookId == book.BookId);
            Books[b] = book;
        }

        public void DeleteBook(int book)
        {
            var b = Books.FindIndex(book => book.BookId == book.BookId);
            Books.RemoveAt(b);
        }
    }
}
