using System.ComponentModel.DataAnnotations;

namespace ContaOnline.UI.Web.Models
{
    public class ContaCategoriaViewModel
    {
        [Required(ErrorMessage = "O nome deve ser informado")]
        public string Nome { get; set; }
    }
}
