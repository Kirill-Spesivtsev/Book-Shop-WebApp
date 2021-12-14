using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_Core_Project.ViewModels
{
    public class ListViewModel<T> : List<T> where T : class
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        private ListViewModel(IEnumerable<T> items, int totalPages, int currentPage) : base(items)
        {
            this.TotalPages = totalPages;
            this.CurrentPage = currentPage;
        }

        public static ListViewModel<T> GetModel(IEnumerable<T> list, int current, int itemsPerPage)
        {
            var items = list.Skip((current - 1) * itemsPerPage).Take(itemsPerPage).ToList();
            var total = (int)Math.Ceiling((double)list.Count() / itemsPerPage);
            return new ListViewModel<T>(items, total, current);
        }
    }
}
