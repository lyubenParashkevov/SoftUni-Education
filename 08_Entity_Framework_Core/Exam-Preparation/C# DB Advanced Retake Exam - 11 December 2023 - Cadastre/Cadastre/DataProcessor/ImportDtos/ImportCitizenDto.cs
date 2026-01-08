using Cadastre.Data.Enumerations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class ImportCitizenDto
    {
        [Required]
        [StringLength(30, MinimumLength = 2)]
        [JsonProperty("FirstName")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; } = null!;

        public string BirthDate { get; set; } = null!;

        public string MaritalStatus { get; set; } = null!;

        public int[] Properties { get; set; } = null!;

    }
}
