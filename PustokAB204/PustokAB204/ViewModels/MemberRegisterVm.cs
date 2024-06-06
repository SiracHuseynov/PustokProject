using System.ComponentModel.DataAnnotations;

namespace PustokAB204.ViewModels;

public class MemberRegisterVm
{
    [Required]
    [MaxLength(50)]
    public string FullName { get; set; }
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [MinLength(8)]
    [Compare(nameof(Password))]
    [DataType(DataType.Password)]
    public string RepeatPassword { get; set; }
}
