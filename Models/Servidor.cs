using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cadastrodeservidores.Models
{
    public class Servidor
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }
        
        public string Email { get; set; }
        
        public DateTime DataNascimento { get; set; }
        
        public Endereco Endereco { get; set; }
        
        public string RF { get; set; }
        
        public int Vinculo { get; set; }
        
        public string Cargo { get; set; }
        
        public string UnidadeLotacao { get; set; }
        
        public string UnidadeExercicio { get; set; }
    }
}