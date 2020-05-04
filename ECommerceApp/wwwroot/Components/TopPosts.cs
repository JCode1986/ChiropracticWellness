using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.wwwroot.Components
{
    [ViewComponent]
    public class TopPosts : ViewComponent
    {
        //do dependency inj and bring in the db context
        private StoreDbContext _context;

        public TopPost(StoreDbContext context)
        {
            _context = context;
        }
    
    //Required or reserved method name is Invoke or InvokeAsync
    //need to Invoke or InvokeAsync a method that returns data
    //Is going to return an IViewComponentResult (vs. a real controller that uses IActionResult)

        public async Task<IViewComponentResult> InvokeAsync(int number)
        {
            var posts = _context.Inventory.OrderByDescending(x => x.ID)
                .Take(number);

            return View();
        }
    }
}
