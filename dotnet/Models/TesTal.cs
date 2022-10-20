using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dotnet.Models
{
    public class TesTal 
    { 

            [Key]
            [Column("id")]
            public int Id { get; set; }

            [Column("nama")]
            public string Nama { get; set; } = null!;

      }

    

}
