using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Web.Pages
{
    public class DisplayProductsBase : ComponentBase
    {
        [Parameter]
        public required IEnumerable<ProductDto> Products { get; set; }  
    }
}
