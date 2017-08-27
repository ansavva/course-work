using Menou.Services.Core.Logic.Concrete;
using Menou.Services.Core.Logic.Contracts;
using Menou.Services.Core.Model;
using Menou.Services.Data.Contracts;
using Menou.Services.Data.Contracts.dbo.Menou;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Menou.Services.Data.Concrete.dbo.Menou
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly IConfigurationSettings _configurationSettings;
        private readonly ISqlFileReader _fileReader;

        public MenuItemRepository(IConfigurationSettings configurationSettings, ISqlFileReader fileReader)
        {
            Guard.IsNotNull(configurationSettings, "configurationSettings");
            Guard.IsNotNull(fileReader, "fileReader");
            _configurationSettings = configurationSettings;
            _fileReader = fileReader;
        }

        /// <summary>
        /// Reads in menu item records for the given restaurant id passed in.
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public List<MenuItem> ReadMenuItems(int restaurantId)
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            using (SqlConnection connection = new SqlConnection(_configurationSettings.Settings("Menou")))
            {
                using (SqlCommand sqlCommand = new SqlCommand(_fileReader.GetSqlCode("ReadRestaurantById", "Menou")))
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.Parameters.Add("@RestaurantId", SqlDbType.Int);
                    sqlCommand.Parameters["RestaurantId"].Value = restaurantId;

                    using (IDataReader reader = sqlCommand.ExecuteReader())
                    {
                        MenuItem menuItem = new MenuItem();

                        menuItem.Id = CustomConverter.ToInt(reader["Id"], -1);
                        menuItem.Title = CustomConverter.ToString(reader["Title"], string.Empty);
                        menuItem.Description = CustomConverter.ToString(reader["Description"], string.Empty);
                        menuItem.CreatedDate = CustomConverter.ToDateTime(reader["CreatedDate"], DateTime.Now);
                        menuItem.ModifiedDate = CustomConverter.ToDateTime(reader["ModifiedDate"], DateTime.Now);

                        menuItems.Add(menuItem);
                    }
                }
            }

            return menuItems;
        }
    }
}
