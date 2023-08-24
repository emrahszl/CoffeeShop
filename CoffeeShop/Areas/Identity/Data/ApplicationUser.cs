using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CoffeeShop.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Required]
    [MaxLength(50)]
    [Display(Name = "First Name")]
    [DataType(DataType.Text)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    [Display(Name = "Last Name")]
    [DataType(DataType.Text)]
    public string LastName { get; set; } = null!;
}

