using System.ComponentModel.DataAnnotations;
namespace prueba.Models
{
    public class Contacts
    {
        [Key]
        public int Identificator { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}