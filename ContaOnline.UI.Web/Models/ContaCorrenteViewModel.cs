using System.ComponentModel.DataAnnotations;

namespace ContaOnline.UI.Web.Models
{
    public class ContaCorrenteViewModel
    {
        [Required(ErrorMessage = "A descrição deve ser informada")]
        public string Descricao { get; set; }
    }
}
