using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

[Table("Family")]
public partial class Family
{
    [Key]
    public int FamilyId { get; set; }

    [StringLength(100)]
    public string FamilyName { get; set; } = null!;

    [InverseProperty("Family")]
    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
}
