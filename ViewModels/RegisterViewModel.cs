using System.ComponentModel.DataAnnotations;

namespace GestStationService.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="L'email est obligatoire")]
        [EmailAddress(ErrorMessage = "Le format de l'email est invalide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [MinLength(6, ErrorMessage = "Minimum 6 caractères")]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }

        [Required(ErrorMessage = "La confirmation est obligatoire")]
        [DataType(DataType.Password)]
        [Compare("MotDePasse", ErrorMessage = "Les mots deux passe ne sont pas identique")]
        public string ConfirmMotDePasse { get; set; }
    }
}
