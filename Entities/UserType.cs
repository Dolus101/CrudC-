using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DizonCoop.Entities;

public partial class UserType
{
    public int Id { get; set; }

    [DisplayName("Enter Name")]
    [Required]
    public string? Name { get; set; }
}
