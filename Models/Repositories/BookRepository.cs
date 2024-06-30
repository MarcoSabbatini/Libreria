using Libreria.Models.Context;
using Libreria.Models.Entities;
using Libreria.Models.Entities.Common;
using Libreria.Service.Models.Requests;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
namespace Libreria.Models.Repositories
{
    public class BookRepository : GenericRepository<Book>
    {
        public BookRepository(MyDbContext ctx) : base(ctx) { }

        public override Book? Get(int id)
        {
            var book = base._ctx.Books
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if(book == null)
            {
                throw new Exception("Select another index, there are no books corresponding to this index");
            }
            var categories = base._ctx.Books
                .Where(x => x.Id ==  book.Id)
                .SelectMany(x => x.Categories)//takes all the categories appended(nested) to all the books
                .Select(x => new Category { Id = x.Id, Name = x.Name})//transforms each category object into a new category without the books nested 
                .Distinct()
                .ToList();
            book.Categories = categories;

            return book;
        }

        public List<Book> GetAll()
        {
            var books = base._ctx.Books.ToList();

            foreach (var book in books)
            {
                var categories = base._ctx.Books
                    .Where(x => x.Id == book.Id)
                    .SelectMany(x => x.Categories)//takes all the categories appended(nested) to all the books
                    .Select(x => new Category { Id = x.Id, Name = x.Name })//transforms each category object into a new category without the books nested 
                    .Distinct()
                    .ToList();
                book.Categories = categories;
            }

            return books;
        }

        public Book Modify(Book book)
        {
            Book _book = _ctx.Books.Include(x => x.Categories).First(x => x.Id == book.Id);

            if(_book == null)
            {
                throw new Exception("Select another index, there are no books corresponding to this index");
            }

            _book.Name = book.Name;
            _book.Author = book.Author;
            _book.PublishingDate = book.PublishingDate;
            _book.Editor = book.Editor;
            _book.Categories = new List<Category>();

            var cats = book.Categories;
            //checks whether the cat exists or not in the db, if not adds in it and in the _book
            foreach (var category in cats)
            {

                Category cat = _ctx.Categories.Where(x => x.Name == category.Name).First();
                if(cat == null)
                {
                    _ctx.Categories.Add(category);
                    _ctx.SaveChanges();
                    _book.Categories.Add(category);
                }
                _book.Categories.Add(cat);
            }

            _ctx.Update(_book);
            Save();
            return _book;
        }

        
        public override void Add(Book book)
        {
            var cats = book.Categories;
            book.Categories = [];
            _ctx.Books.Add(book);

            ICollection<Category> categories = new List<Category>();
            foreach (var category in cats) { 
                Category cat = _ctx.Categories.First(x => x.Name == category.Name);
                if (cat == null)
                {
                    _ctx.Categories.Add(category);
                    Save();
                    categories.Add(_ctx.Categories.First(x => x.Name == category.Name));
                } else
                {
                    categories.Add(cat);
                }
            }
            Save();
            book.Categories = categories;
            _ctx.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public ICollection<Book> GetAllByFilter(Book book, DateTime? after, DateTime? before, int pageSize, int pageCount)
        {
            List<Book> outcome = new List<Book>();
            var books = _ctx.Books;

            IQueryable<Book> query = books.Where(x => x.PublishingDate >= after && x.PublishingDate <= before);
            if (book.Name != String.Empty)
            {
                query = query.Where(x => x.Name == book.Name);
            }
            if (book.Author != String.Empty)
            {
                query = query.Where(x => x.Author == book.Author);
            }
            ICollection<Book> aux = query.ToList();

            return outcome;
        }

            /*public List<Book> GetAllByFilter(BookRequest bookForFilters)
            {

                if (bookForFilters.Filters.Count == 0) return null;
                IQueryable<Book> query = _ctx.Books;

                foreach (var filter in bookForFilters.Filters)
                {
                    switch (filter)
                    {
                        case SearchFilters.CATEGORY:
                            query = query.Where(x => x.Categories.Any(c => c.Name.Equals(bookForFilters.Category)));
                            break;
                        case SearchFilters.NAME:
                            query = query.Where(x => x.Name.Equals(bookForFilters.Name));
                            break;
                        case SearchFilters.AUTHOR:
                            query = query.Where(x => x.Author.Equals(bookForFilters.Author));
                            break;
                        case SearchFilters.PUBLISHINGDATE:
                            query = query.Where(x => x.PublishingDate.Equals(bookForFilters.PublishingDate));
                            break;
                        default:
                            break;
                    }
                }
                return query.ToList();
            }*/

            private List<Category> AddCat(Book book)
        {
            return base._ctx.Books
                .Where(x => x.Id == book.Id)
                .SelectMany(x => x.Categories)//takes all the categories appended(nested) to all the books
                .Select(x => new Category { Id = x.Id, Name = x.Name })//transforms each category object into a new category without the books nested 
                .Distinct()
                .ToList();
        }
    }
}
