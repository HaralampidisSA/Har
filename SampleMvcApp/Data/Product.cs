using Har.Domain.Entities.Auditing;

namespace SampleMvcApp.Data
{
    public class Product : FullAuditedEntity<int, ApplicationUser>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
