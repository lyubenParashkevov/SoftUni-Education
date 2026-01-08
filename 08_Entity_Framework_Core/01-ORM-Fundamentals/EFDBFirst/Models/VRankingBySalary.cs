using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFDBFirst.Models;

[Keyless]
public partial class VRankingBySalary
{
    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Salary { get; set; }

    public long? Rank { get; set; }
}
