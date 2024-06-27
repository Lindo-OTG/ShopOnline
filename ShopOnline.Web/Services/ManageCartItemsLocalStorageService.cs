using Blazored.LocalStorage;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Services
{
    public class ManageCartItemsLocalStorageService : IManageCartItemsLocalStorageService
    {

        private readonly ILocalStorageService localStorageService;
        private readonly IShoppingCartService shoppingCartService;

        private const string key = "CartItemCollection";

        public ManageCartItemsLocalStorageService(ILocalStorageService localStorageService,
                                                 IShoppingCartService shoppingCartService)
        {
            this.localStorageService = localStorageService;
            this.shoppingCartService = shoppingCartService;
        }

        public async Task<IEnumerable<CartItemDto>> GetCollection()
        {
            return await this.localStorageService.GetItemAsync<List<CartItemDto>>(key)
                    ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await this.localStorageService.RemoveItemAsync(key);
        }

        public async Task SaveCollection(List<CartItemDto> cartItemDtos)
        {
            await this.localStorageService.SetItemAsync(key, cartItemDtos);
        }

        private async Task<IEnumerable<CartItemDto>> AddCollection()
        {
            var cartItemCollection = await shoppingCartService.GetItems(HardCoded.UserId);

            if (cartItemCollection != null)
            {
                await localStorageService.SetItemAsync(key, cartItemCollection);
            }

            return cartItemCollection;

        }
    }
}
