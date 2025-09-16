using Blog.Core.DTos;
using Blog.Core.Interfaces;
using Blog.Core.Models;
using Blog.Inrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Inrastructure.Services
{
    public class CategoryService : ICategoryService
    {

        // DI
        private readonly BlogDbContext _context;
        public CategoryService(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var Categories = await _context.Categories.ToListAsync();
            //var Categories =  _context.Categories.Select(c => new Category
            //{
            //    Name = c.Name,
            //    Id = c.Id,
            //    //Posts = c.Posts
            //});
            return Categories;
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
            //return await _context.Categories.FirstAsync(c => c.Id == id);
            //return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            //return await _context.Categories.SingleAsync(c => c.Id == id);
            //return await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Category> CreateAsync(CategoryDTo category)
        {
            var Category = new Category
            {
                Name = category.Name,
            };
            await _context.Categories.AddAsync(Category);
            await _context.SaveChangesAsync();
            return Category;
        }
        public async Task<bool> UpdateAsync(int id, CategoryDTo category)
        {
            //var OldCateory = await _context.Categories.FindAsync(id);
            var OldCateory = await GetByIdAsync(id);
            if(OldCateory is null)
                return false;
            OldCateory.Name = category.Name;
            _context.Categories.Update(OldCateory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(CategoryDTo category)
        {
            var OldCategory = await GetByIdAsync(category.Id);
            if(OldCategory is null)
                return false;
            OldCategory.Name = category.Name;
            _context.Categories.Update(OldCategory);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var Category  = await GetByIdAsync(id);
            if(Category is null)
                return false;
            _context.Categories.Remove(Category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
