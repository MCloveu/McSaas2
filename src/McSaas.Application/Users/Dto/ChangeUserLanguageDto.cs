using System.ComponentModel.DataAnnotations;

namespace McSaas.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}