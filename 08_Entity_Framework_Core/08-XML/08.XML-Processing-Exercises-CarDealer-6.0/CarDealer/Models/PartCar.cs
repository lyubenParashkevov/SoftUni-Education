using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Models
{
    public class PartCar
    {
        [Key]
        [InverseProperty(nameof(Part))]
        public int PartId { get; set; }
        public virtual Part Part { get; set; } = null!; 

        [Key]
        [InverseProperty(nameof(Car))]
        public int CarId { get; set; }
        public virtual Car Car { get; set; } = null!; 
    }
}
