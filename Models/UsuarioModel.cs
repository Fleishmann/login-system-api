using System.ComponentModel.DataAnnotations;

namespace HMZ_API.Models
{
    public class UsuarioModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string senha { get; set; }

    }
}
