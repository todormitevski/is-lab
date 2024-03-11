using System.ComponentModel.DataAnnotations;

namespace Concert.Web.Models
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }
        public int NumberOfPeople { get; set; }
        public virtual AppUser? AppUser { get; set; }
        // another Guid for relationship
        public Guid ConcertId { get; set; }
        public virtual ConcertModel? Concert { get; set; }
    }
}
