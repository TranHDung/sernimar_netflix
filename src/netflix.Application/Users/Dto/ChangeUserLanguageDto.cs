using System.ComponentModel.DataAnnotations;

namespace netflix.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}