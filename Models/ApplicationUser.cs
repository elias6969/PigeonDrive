namespace PigeonDrive.Api.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser
    {
        public ICollection<Folder> Folders { get; set; } = new List<Folder>();
    }
}
