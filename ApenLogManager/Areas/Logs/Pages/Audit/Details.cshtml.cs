using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apen;
using Apen.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApenLogManager.Logs.Pages.Audit
{
    public class DetailsModel : PageModel
    {
        private readonly LoggerDbContext _context;
        public DetailsModel(LoggerDbContext context)
        {
            _context = context;
        }
        public AuditLog Item { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Item = await _context.AuditLogs.FirstOrDefaultAsync(q => q.Id == id);
            if (Item == null)
                return NotFound();
            return Page();
        }
    }
}
