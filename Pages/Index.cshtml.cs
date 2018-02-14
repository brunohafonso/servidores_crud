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
    public class IndexModel : PageModel
    {
        readonly PmspContext _context;

        [TempData]
        public string Mensagem { get; set; }
        
        public IList<Servidor> Servidores { get; set; }
        
        public IndexModel(PmspContext context)
        {
            _context = context;
        }

        
        public async Task OnGetAsync()
        {
            Servidores = await _context.Servidores.AsNoTracking().ToListAsync();
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
