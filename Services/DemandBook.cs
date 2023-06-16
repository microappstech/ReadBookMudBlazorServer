using Microsoft.AspNetCore.Components;
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
        
        
        

    }
}
