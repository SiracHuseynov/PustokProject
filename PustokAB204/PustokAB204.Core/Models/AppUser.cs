using Microsoft.AspNetCore.Identity;

namespace PustokAB204.Core.Models;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
}
