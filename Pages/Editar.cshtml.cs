using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using cadastrodeservidores.Dados;
using cadastrodeservidores.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace cadastrodeservidores.Pages
{
    public class EditarModel : PageModel
    {
       readonly PmspContext _context;
       
       [BindProperty]
       public Servidor Servidor { get; set; }

       [BindProperty] 
       public Endereco Endereco { get; set; }
       
       
       public EditarModel(PmspContext context)
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

       public async Task<IActionResult> OnPostAsync() 
       {
           if(!ModelState.IsValid)
           {
               return Page();
           }

           _context.Servidores.Attach(Servidor).State = EntityState.Modified;
           try
           {
               await _context.SaveChangesAsync();
           }
           catch (DbUpdateConcurrencyException ex)
           {
               throw new Exception($"Erro ao atualizar {Servidor.Nome} " + ex.Message);
           }
           
           return RedirectToPage("/Index");
       }
    }
}