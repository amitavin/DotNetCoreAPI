namespace RestaurantApi.API.Models
{
    /// <summary>
    /// DTO used for creating or updating MenuItem entities via the API.
    /// </summary>
    public class MenuItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
    }
}
