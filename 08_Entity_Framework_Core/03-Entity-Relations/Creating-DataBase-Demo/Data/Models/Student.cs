using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creating_DataBase_Demo.Data.Models
{
    public class Student    //created with FlientApi
    {
        public int StudentPk { get; set; }  //if propName contains Id, aumaticly this become PK, Identity

        public string Name { get; set; } = string.Empty;

        public string FacultyNumber { get; set; } = string.Empty;
        public int Semester {  get; set; }

        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; } = null!;
        public int? RoomId { get; set; }

        [ForeignKey(nameof (RoomId))]
        public Room? Room { get; set; }

        IList<StudentsCourses> Courses { get; set; } = new List<StudentsCourses>();  //many to many
    }
}
