using System.ComponentModel.DataAnnotations;

namespace Concert.Web.Models
{
    public class ConcertModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string ConcertName { get; set; }
        public DateTime ConcertDate { get; set; }
        public decimal ConcertPrice { get; set; }
        public string ConcertPlace { get; set; }
        public string? ConcertUrl { get; set; }
    }
}
