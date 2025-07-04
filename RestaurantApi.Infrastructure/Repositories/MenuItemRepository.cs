using MongoDB.Driver;
using RestaurantApi.Domain.Entities;
using RestaurantApi.Infrastructure.Data;

namespace RestaurantApi.Infrastructure.Repositories
{
    /// <summary>
    /// Handles CRUD operations for MenuItems.
    /// </summary>
    public class MenuItemRepository
    {
        private readonly IMongoCollection<MenuItem> _menuItems;

        public MenuItemRepository(MongoContext context)
        {
            _menuItems = context.MenuItems;
        }

        public async Task<List<MenuItem>> GetAllAsync()
            => await _menuItems.Find(_ => true).ToListAsync();

        public async Task<MenuItem?> GetByIdAsync(string id)
            => await _menuItems.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(MenuItem item)
            => await _menuItems.InsertOneAsync(item);

        public async Task UpdateAsync(MenuItem item)
            => await _menuItems.ReplaceOneAsync(x => x.Id == item.Id, item);

        public async Task DeleteAsync(string id)
            => await _menuItems.DeleteOneAsync(x => x.Id == id);
    }
}
