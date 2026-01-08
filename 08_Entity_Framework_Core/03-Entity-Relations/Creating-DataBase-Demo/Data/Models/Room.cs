using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creating_DataBase_Demo.Data.Models
{
    [Table("Rooms", Schema= "uni")]
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]

        public int RoomNumber { get; set; }

        public IList<Student> Students { get; set; } = new List<Student>();
    }
}
