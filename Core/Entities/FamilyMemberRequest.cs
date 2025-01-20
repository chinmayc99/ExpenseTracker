using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

[Table("FamilyMemberRequest")]
public partial class FamilyMemberRequest
{
    [Key]
    public int FamilyMemberRequestId { get; set; }

    public int? RequestedUserId { get; set; }

    [StringLength(500)]
    public string UserMessage { get; set; } = null!;

    [StringLength(100)]
    public string FamilyEmailIds { get; set; } = null!;

    public bool? IsEmailSent { get; set; }

    public bool? IsProcessed { get; set; }

    [ForeignKey("RequestedUserId")]
    [InverseProperty("FamilyMemberRequests")]
    public virtual UserProfile? RequestedUser { get; set; }
}
