using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LothricCritic.ViewComponents
{
    public class CategoryList:ViewComponent
    {
        private readonly Context _context;

        public CategoryList(Context context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int gameId)
        {
            var game = await _context.Games.Include(g=>g.Categories).FirstOrDefaultAsync(m=>m.GameID == gameId);

            var categoryName = game.Categories.Select(gc => gc.CategoryName).ToList();
            return View(categoryName);
        }
    }
}
