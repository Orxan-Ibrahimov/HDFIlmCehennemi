
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;

namespace HDF.PresentationLayer.Backend.ViewModels
{
    public class PaginationViewModel<T>
    {
        public PaginationViewModel(List<T> data, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = data.Count();
            LastPageIndex = (int)Math.Ceiling(TotalCount * 1.0 / PageSize);
            Data = data.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
        }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int LastPageIndex { get; private set; }
        public int TotalCount { get; private set; }
        public int MaxPage { get; private set; }
        public List<T> Data { get; set; }

        public string Getpagination(IUrlHelper url, string action)
        {
            if (TotalCount <= PageSize)
                return "";

            StringBuilder pag = new StringBuilder();
            pag.Append("<ul class='pagination-list bg-shadow'>");

            if (PageIndex != 1)
            {
                var link = url.Action(action, values: new
                {
                    PageIndex = this.PageIndex - 1,
                    PageSize = this.PageSize
                });
                 
                pag.Append($"<li class='pagination-item'><a href='{link}' class='pagination-link'>Önceki Sayfa</a></li>");
            }
            for (int i = 1; i <= LastPageIndex; i++)
            {
                if (((i <= (PageIndex + 2) && i >= (PageIndex - 2))))
                {
                    if (PageIndex == i)
                        pag.Append($"<li class='pagination-item active'><a class='pagination-link pagination-circle'>{i}</a></li>");
                    else
                    {
                        var link = url.Action(action, values: new
                        {
                            PageIndex = i,
                            PageSize = this.PageSize
                        });

                        pag.Append($"<li class='pagination-item'><a href='{link}' class='pagination-link pagination-circle'>{i}</a></li>");

                    }
                }
            }

            if (PageIndex != LastPageIndex)
            {
                var link = url.Action(action, values: new
                {
                    PageIndex = this.PageIndex + 1,
                    PageSize = this.PageSize
                });

                pag.Append($"<li class='pagination-item'><a href='{link}' class='pagination-link'>Sonraki Sayfa</a></li>");
            }

            pag.Append("</ul>");
            return pag.ToString();
        }

    }
}
