using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cadastrodeservidores.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Logradouro { get; set; }
        
        [Required]
        public int Numero { get; set; }
        
        public string Complemento { get; set; }
        
        [Required]
        [StringLength(10)]
        public string CEP { get; set; }
    }
}