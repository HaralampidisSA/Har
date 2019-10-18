using Har.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace SampleMvcApp.Data
{
    public class ApplicationUser : IdentityUser, IEntity<string>
    {
    }
}
