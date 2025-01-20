using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

[Table("EmailCopy")]
public partial class EmailCopy
{
    [Key]
    public int EmailCopyId { get; set; }

    [StringLength(100)]
    public string EmailFrom { get; set; } = null!;

    [StringLength(100)]
    public string EmailTo { get; set; } = null!;

    [StringLength(100)]
    public string EmailSubject { get; set; } = null!;

    [StringLength(2000)]
    public string EmailMessage { get; set; } = null!;

    public DateTime SentDate { get; set; }
}
