using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using ReadBookMuds.Data;

namespace ReadBookMuds.Services
{
    public partial class Service
    {
        
        private readonly ReadBookContext _context;
        private readonly NavigationManager UriHelper;
        public Service(ReadBookContext context, NavigationManager navigation)
        {
            this._context = context;    
            this.UriHelper = navigation;
        }
        public void Reset()
        {
            _context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(en => en.State = EntityState.Detached);
        }
    }
}
