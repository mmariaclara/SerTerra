using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SerTerraQueijaria.Models
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "É necessário ter um Nome.")]
        public string Nome { get; set; }

        [DisplayName("Telefone")]
        [Required(ErrorMessage = "É necessário ter um Telefone.")]
        public string Fone { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "É necessário ter um E-mail.")]
        public string Email { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "É necessário ter um CPF.")]
        public string Cpf { get; set; }
    }
}
