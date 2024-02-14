namespace BookWorm.Models
{
    public interface IBook
    {
        public void CreateBook(Book book);
        public void UpdateBook(Book book);
        public void DeleteBook(int id);
        public List<Book> GetBooks();
        public Book? GetBook(int id);

    }
}
