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

namespace cadastrodeservidores.Pages
{
    public class CadastrarModel : PageModel
    {
       readonly PmspContext _context;

       [TempData]
       public string Mensagem { get; set; }
       
       [BindProperty]
       public Servidor Servidor { get; set; }
       
       public CadastrarModel(PmspContext context)
       {
           _context = context;
       } 

       public async Task<IActionResult> OnPostAsync() 
       {
           if(!ModelState.IsValid)
           {
               return Page();
           }

           _context.Servidores.Add(Servidor);
           await _context.SaveChangesAsync();
           var msg = $"Servidor: {Servidor.Nome} inserido com sucesso";
           Mensagem = msg;
           return RedirectToPage("/Index");

       }
    }
}