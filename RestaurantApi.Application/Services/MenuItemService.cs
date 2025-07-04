using RestaurantApi.Domain.Entities;
using RestaurantApi.Infrastructure.Repositories;

namespace RestaurantApi.Application.Services
{
    /// <summary>
    /// Business logic layer for MenuItems.
    /// </summary>
    public class MenuItemService
    {
        private readonly MenuItemRepository _repository;

        public MenuItemService(MenuItemRepository repository)
        {
            _repository = repository;
        }

        public Task<List<MenuItem>> GetAllAsync() => _repository.GetAllAsync();
        public Task<MenuItem?> GetByIdAsync(string id) => _repository.GetByIdAsync(id);
        public Task CreateAsync(MenuItem item) => _repository.CreateAsync(item);
        public Task UpdateAsync(MenuItem item) => _repository.UpdateAsync(item);
        public Task DeleteAsync(string id) => _repository.DeleteAsync(id);
    }
}
