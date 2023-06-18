using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using ReadBookMuds.Data;
using ReadBookMuds.Models;
using System.Runtime.CompilerServices;

namespace ReadBookMuds.Services
{
    public partial class Service
    {
        
        public async Task<DemandBook> DemandeBook(DemandBook demandBook)
        {
            _context.DemandsBooks.Add(demandBook);
            try 
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return await Task.FromResult(demandBook);
        }

        public async Task<List<DemandBook>> GetOrders()
        {
            var items = _context.DemandsBooks.Include(i=>i.book).ToList();
            
            return await Task.FromResult(items);
        }

        public async Task<DemandBook> GetDemandBookById(int id)
        {
            var demand = _context.DemandsBooks.Find(id);
            return await Task.FromResult(demand);
        }

        public async Task<DemandBook> EditDemand(int id, DemandBook demandBook)
        {
            var demandToUpdate = _context.DemandsBooks.Find(id);
            
            if(demandToUpdate == null)
            {
                throw new Exception("order no loger availlable ");
            }
            demandToUpdate.username = demandBook.username;
            demandToUpdate.nbr = demandBook.nbr;
            demandToUpdate.phone = demandBook.phone;
            demandToUpdate.bookId = demandBook.bookId;
            demandToUpdate.Addresse = demandBook.Addresse;
            demandToUpdate.Email = demandBook.Email;
            demandToUpdate.book = demandBook.book;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex) 
            {

            }
            return await Task.FromResult(demandToUpdate);

        }

        public async Task<DemandBook> DeleteDemand(int id)
        {
            var demandToDelete = _context.DemandsBooks.Find(id);
            if(demandToDelete == null)
            {
                throw new Exception("demand already deleted");
            }
            _context.DemandsBooks.Remove(demandToDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return await Task.FromResult(demandToDelete);
        }



    }
}
