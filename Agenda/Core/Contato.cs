using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Core
{
    [Table("Contato")]
    public class Contato
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName="varchar"),StringLength(60)]
        public string Nome { get; set; }

        [Column(TypeName = "varchar"), StringLength(60)]
        public string Email { get; set; }
        
        [Column(TypeName = "varchar")]
        [StringLength(12)]
        public string Telefone { get; set; }

    }
}
