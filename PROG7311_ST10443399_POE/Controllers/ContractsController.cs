using Microsoft.AspNetCore.Mvc;
using PROG7311_ST10443399_POE.Data;
using PROG7311_ST10443399_POE.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PROG7311_ST10443399_POE.Controllers
{
    public class ContractsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContractsController(ApplicationDbContext context) => _context = context;

        // LINQ Search/Filter Logic
        public async Task<IActionResult> Index(string status, DateTime? start, DateTime? end)
        {
            var query = _context.Contracts.AsQueryable();
            if (!string.IsNullOrEmpty(status)) query = query.Where(c => c.Status == status);
            if (start.HasValue && end.HasValue) query = query.Where(c => c.StartDate >= start && c.EndDate <= end);
            return View(await query.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contract contract, IFormFile pdfFile)
        {
            if (pdfFile != null && pdfFile.ContentType == "application/pdf")
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                string fileName = Guid.NewGuid().ToString() + "_" + pdfFile.FileName;
                using (var stream = new FileStream(Path.Combine(folder, fileName), FileMode.Create))
                {
                    await pdfFile.CopyToAsync(stream);
                }
                contract.SignedAgreementPath = fileName;
            }
            _context.Add(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
