using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadBookMuds.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Icon { get; set; }
        public DateTime LastSeen { get; set; }
        [NotMapped] public IList<string> Roles { get; set; }
    }
}
