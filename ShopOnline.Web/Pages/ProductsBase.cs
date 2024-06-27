using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ProductsBase : ComponentBase
    {
        [Inject]
        public required IProductService ProductService { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public IManageCartItemsLocalStorageService ManageCartItemsLocalStorageService { get; set; }

        [Inject]
        public IManageProductsLocalStorageService ManageProductsLocalStorageService { get; set; }  

        public required IEnumerable<ProductDto> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ClearLocalStorge();

            Products = await ManageProductsLocalStorageService.GetCollection();
            var shoppingCartItems = await ManageCartItemsLocalStorageService.GetCollection();

            var totalQty = shoppingCartItems.Sum(i => i.Qty);

            ShoppingCartService.RaiseEventOnSHoppingCartChanged(totalQty);
        }

        protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupedProductByCategory()
        {
            return from product in Products
                   group product by product.CategoryId into prodByCatGroup
                   orderby prodByCatGroup.Key
                   select prodByCatGroup;
        }

        protected string GetCategoryName(IGrouping<int, ProductDto> groudpedProductDtos)
        {
            return groudpedProductDtos.FirstOrDefault(pg => pg.CategoryId == groudpedProductDtos.Key).CategoryName;
        }

        private async Task ClearLocalStorge()
        {
            await ManageCartItemsLocalStorageService.RemoveCollection();
            await ManageProductsLocalStorageService.RemoveCollection();
        }

    }
}
