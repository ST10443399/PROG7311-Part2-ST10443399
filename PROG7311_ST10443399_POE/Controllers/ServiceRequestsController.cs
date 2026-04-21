using Microsoft.AspNetCore.Mvc;
using PROG7311_ST10443399_POE.Data;
using PROG7311_ST10443399_POE.Models;

namespace PROG7311_ST10443399_POE.Controllers
{
    public class ServiceRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ServiceRequestsController(ApplicationDbContext context) => _context = context;

        /*public IActionResult Index()
        {
            return View();
        }*/

        [HttpPost]
        public async Task<IActionResult> Create(ServiceRequest sr)
        {
            var contract = await _context.Contracts.FindAsync(sr.ContractId);

            // Workflow Logic: Check Status
            if (contract!.Status == "Expired" || contract.Status == "On Hold")
            {
                ModelState.AddModelError("", "Cannot create request for Expired/On Hold contracts.");
                return View(sr);
            }

            // External API Integration
            using (var client = new HttpClient())
            {
                var data = await client.GetFromJsonAsync<dynamic>("https://open.er-api.com/v6/latest/USD");
                decimal rate = data!.rates.ZAR;
                sr.CostZAR = sr.CostUSD * rate; // Auto-calculation
            }

            _context.Add(sr);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
