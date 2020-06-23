using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Apen;
using Apen.Entity;
using Microsoft.EntityFrameworkCore;
using Apen.Extensions;

namespace ApenLogManager.Logs.Pages.Audit
{
    public class IndexModel : PageModel
    {
        private readonly LoggerDbContext _context;
        public IndexModel(LoggerDbContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<AuditLog> Items { get; set; }
        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(SearchString))
                Items = await _context.AuditLogs.Where(q => q.Reference.Contains(SearchString) || q.Detail.Contains(SearchString)).AsNoTracking().ToListAsync();
            else
                Items = await _context.AuditLogs.OrderByDescending(q => q.Id).Take(10).AsNoTracking().ToListAsync();
        }
    }
}
