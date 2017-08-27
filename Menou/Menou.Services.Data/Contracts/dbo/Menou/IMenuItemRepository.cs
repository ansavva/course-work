using Menou.Services.Core.Model;
using System.Collections.Generic;

namespace Menou.Services.Data.Contracts.dbo.Menou
{
    public interface IMenuItemRepository
    {
        List<MenuItem> ReadMenuItems(int restaurantId);
    }
}
