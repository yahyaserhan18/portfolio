using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<PortfolioItem> _portfolioItem;

        public HomeController(IUnitOfWork<Owner> owner , IUnitOfWork<PortfolioItem> PortfolioItem)
        {
            _owner = owner;
            _portfolioItem = PortfolioItem;
        }


        public async Task<IActionResult> Index()
        {
            HomeViewModel model = new HomeViewModel
            {
                Owner =await _owner.Entity.FirstOrDefaultAsync() ?? new Owner(),
                PortfolioItems = await _portfolioItem.Entity.GetAllAsync()
            };
            return View(model);
        }
    }
}
