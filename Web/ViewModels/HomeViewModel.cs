using Core.Entities;

namespace Web.ViewModels
{
    public class HomeViewModel
    {
        public Owner Owner { get; set; } = null!;
        public IEnumerable<PortfolioItem>? PortfolioItems { get; set; }
    }
}
