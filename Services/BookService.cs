﻿using Microsoft.EntityFrameworkCore;
using ReadBookMuds.Data;
using System.Linq;
using ReadBookMuds.Models;
using static MudBlazor.CategoryTypes;
using System.Security.Claims;

namespace ReadBookMuds.Services
{
    public partial class Service 
    {
        public async Task<IEnumerable<Book>> GetBooks()
        {
            var items = _context.Books.AsQueryable();
            items = items.Include(b => b.Category);
            return items.ToList();
        }
        public async Task<Book> GetSingleBook(int id)
        {
            var books = _context.Books.AsNoTracking().Where(i => i.Id == id);
            books = books.Include(c => c.Category);
            var book = books.FirstOrDefault();
            return await Task.FromResult(book);
        }
        public async Task<Book> EditBook(Book book)
        {
            var bookToEdit = _context.Books.Where(i=>i.Id == book.Id).FirstOrDefault();
            if (bookToEdit == null)
            {
                throw new Exception("The book no longer availlable");
            }
            try
            {
                bookToEdit.Author = book.Author;
                bookToEdit.Title = book.Title;
                bookToEdit.Description = book.Description;
                bookToEdit.Datepublication = book.Datepublication;
                bookToEdit.DateAdd = book.DateAdd;
                bookToEdit.Icon = book.Icon;
                bookToEdit.Price = book.Price;
                bookToEdit.CategoryId = book.CategoryId;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                _context.Entry(bookToEdit).State = EntityState.Unchanged;
                throw;
            }
            return bookToEdit;
        }
        public async Task<Book> CreateBook(Book book)
        {
            var IsExist = _context.Books.Where(i => i.Id == book.Id).FirstOrDefault();
            if (IsExist != null)
            {
                throw new Exception("The book already exist");
            }
            _context.Books.Add(book);
            try
            {
                _context.Entry(book).State = EntityState.Added;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _context.Entry(book).State = EntityState.Unchanged;
                throw;
            }
            return book;
        }
        public async Task<Book> DeleteBook(int id)
        {
            var bookToDelete = _context.Books.Where(i => i.Id == id).FirstOrDefault();
            if (bookToDelete == null)
            {
                throw new Exception("The book not exsit ");
            }
            _context.Entry(bookToDelete).State = EntityState.Detached;
            _context.Books.Remove(bookToDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _context.Entry(bookToDelete).State = EntityState.Unchanged;
                throw;
            }
            return bookToDelete;
        }
    }
}
