using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("user")]
public class User {

    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "name_required_msg")]
    public string Name { get; set; }

    [Required(ErrorMessage = "password_required_msg")]
    public string Password { get; set; }

    [Required(ErrorMessage = "email_required_msg")]
    [EmailAddress(ErrorMessage = "email_invalid_msg")]
    public string Email { get; set; }

    [Required(ErrorMessage = "dob_required_msg")]
    public DateTime Dob { get; set; }

    [Required(ErrorMessage = "gender_required_msg")]
    public string Gender { get; set; }
}