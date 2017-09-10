using Ecommerce.Services.Core.Model;
using System.Collections.Generic;

namespace Ecommerce.Services.Data.Contracts.dbo.Ecommerce
{
    public interface IMenuItemRepository
    {
        List<MenuItem> ReadMenuItems(int restaurantId);
    }
}
