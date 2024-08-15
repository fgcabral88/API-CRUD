using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Produto
    {
        [Key]
        public int? Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Decricao { get; set; }
    }
}
