using ShopOnline.Models.Dtos;

namespace ShopOnline.Web.Services.Contracts
{
    public interface IManageCartItemsLocalStorageService
    {
        Task<IEnumerable<CartItemDto>> GetCollection();
        Task SaveCollection(List<CartItemDto> cartItemDtos);
        Task RemoveCollection();
    }
}
