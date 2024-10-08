﻿using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;
using Microsoft.EntityFrameworkCore;

namespace DAL_Bibliotheque.Services
{
    public class BookAuthorService : IBookAuthorRepository<BookAuthor>
    {
        private DataContext _context;
        public BookAuthorService(DataContext context)
        {
            _context = context;
        }

        public void Delete(int BookID, int AuthorID)
        {
            var bookAuthor = _context.BookAuthors.Find(BookID, AuthorID);
            if (bookAuthor != null)
            {
                _context.BookAuthors.Remove(bookAuthor);
                _context.SaveChanges();
            }
        }

        public void Insert(BookAuthor entity)
        {
            try
            {
                _context.BookAuthors.Add(entity.ToEF());
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Invalid Author");
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Invalid Author");
            }
        }
    }
}
