using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetBookWithAuthor(int id);
        Task<IReadOnlyList<Book>> GetBooksWithAuthors();
    }
}
