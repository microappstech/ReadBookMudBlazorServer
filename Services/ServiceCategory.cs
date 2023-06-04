using ReadBookMuds.Models;
using Microsoft.EntityFrameworkCore;
using static MudBlazor.Defaults;
using System.Security.Claims;

namespace ReadBookMuds.Services
{
    public partial class Service
    {

        public async Task<List<Category>> GetCategories()
        {
            var items = _context.Categories.ToList();
            return items;
        }
        public async Task<Category> GetSingleCategory(int id)
        {
            var categoy = _context.Categories.FirstOrDefault(i => i.Id == id);
            return categoy;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _context.Entry(category).State = EntityState.Detached;
                throw ;
            }
            return category;
        }
        public async Task<Category> DeleteCategory(int id)
        {
            var IsExist =await _context.Categories.FindAsync(id);
            if (IsExist == null)
            {
                throw new Exception("Category no longer exist");
            }
            _context.Categories.Remove(IsExist);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _context.Entry(IsExist).State = EntityState.Detached;
                throw;
            }
            return IsExist;
        }
        public async Task<Category> EditCategory(int id,Category category)
        {
            var IsExist = await Context.Categories.FindAsync(id);
            if (IsExist == null)
            {
                throw new Exception("Category no longer exist");
            }
            try
            {
                var CategoryToUpdate = Context.Entry(IsExist);
                CategoryToUpdate.CurrentValues.SetValues(category);

                CategoryToUpdate.State = EntityState.Modified;
                Context.SaveChanges();

                
            }
            catch (Exception ex)
            {
                Context.Entry(IsExist).State = EntityState.Detached;
                throw;
            }
            return IsExist;
        }
    }
}
