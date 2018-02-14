using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cadastrodeservidores.Dados;
using cadastrodeservidores.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cadastrodeservidores.Pages
{
    public class DetalhesModel : PageModel
    {
        readonly PmspContext _context;

        public Servidor Servidor { get; set; }

        public Endereco Endereco { get; set; }
        
        
        public DetalhesModel(PmspContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int Id) 
        {
            Servidor = await _context.Servidores.FindAsync(Id);
            Endereco = await _context.Enderecos.FindAsync(Id);
            Servidor.Endereco = Endereco;
            if(Servidor == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }   

         public async Task<IActionResult> OnPostDeleteAsync(int Id) 
        {
            var servidor = await _context.Servidores.FindAsync(Id);

            if(servidor != null) 
            {
                _context.Servidores.Remove(servidor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
} 