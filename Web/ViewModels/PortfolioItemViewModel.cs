namespace Web.ViewModels
{
    public class PortfolioItemViewModel
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? File { get; set; } 
    }
}
