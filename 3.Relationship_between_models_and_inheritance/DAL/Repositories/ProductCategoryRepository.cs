using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
		EntityDatabase _database;

		public ProductCategoryRepository(EntityDatabase database)
        {
			_database = database;

		}
        public async Task<bool> Create(Category entity)
        {
            using (EntityDatabase database = _database)
            {
                await database.Categories.AddAsync(entity);
                await database.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> Delete(Category entity)
        {
            using (EntityDatabase database = _database)
            {
                database.Categories.Remove(entity);
                await database.SaveChangesAsync();
            }
            return true;
        }


        public async Task<Category> Update(Category entity)
        {
            using (EntityDatabase database = _database)
            {
                database.Categories.Update(entity);
                await database.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<Category?> Get(Guid id)
        {
            using (EntityDatabase database = _database)
            {
                return await database.Categories.FirstOrDefaultAsync(product => product.Id == id);
            }
            
        }

        public async Task<Category?> GetByName(string name)
        {
            using (EntityDatabase database = _database)
            {
                return await database.Categories.FirstOrDefaultAsync(product => product.Name == name);
            }
        }

        public async Task<List<Category>> Select()
        {
            using (EntityDatabase database = _database)
            {
                return await database.Categories.ToListAsync();
            }
        }
    }
}
