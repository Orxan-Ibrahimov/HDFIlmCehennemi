using HDF.EntityLayer.Concrete;

namespace HDF.PresentationLayer.Backend.ViewModels
{
    public class HomeVM
    {
        public List<Movie> Movies { get; set; }
        public List<Movie> Series { get; set; }
        public List<Category> Categories { get; set; }
        public List<Category> SpecialCategories { get; set; }
        public PaginationViewModel<Movie> Page { get; set; }
    }
}
