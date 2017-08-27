using Menou.Services.Core.Logic.Concrete;
using Menou.Services.Core.Logic.Contracts;
using Menou.Services.Core.Model;
using Menou.Services.Data.Contracts;
using Menou.Services.Data.Contracts.dbo.Menou;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Menou.Services.Data.Concrete.dbo.Menou
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly IConfigurationSettings _configurationSettings;
        private readonly ISqlFileReader _fileReader;

        public RestaurantRepository(IConfigurationSettings configurationSettings, ISqlFileReader fileReader)
        {
            Guard.IsNotNull(configurationSettings, "configurationSettings");
            Guard.IsNotNull(fileReader, "fileReader");
            _configurationSettings = configurationSettings;
            _fileReader = fileReader;
        }

        /// <summary>
        /// Reads in the restaurant record for the given restaurant id passed in.
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public Restaurant ReadRestaurant(int restaurantId)
        {
            Restaurant restaurant = new Restaurant();

            using (SqlConnection connection = new SqlConnection(_configurationSettings.Settings("Menou")))
            {
                using (SqlCommand sqlCommand = new SqlCommand(_fileReader.GetSqlCode("ReadRestaurantById", "Menou")))
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.Parameters.Add("@RestaurantId", SqlDbType.Int);
                    sqlCommand.Parameters["RestaurantId"].Value = restaurantId;

                    using (IDataReader reader = sqlCommand.ExecuteReader())
                    {
                        restaurant.Id = CustomConverter.ToInt(reader["Id"], -1);
                        restaurant.Name = CustomConverter.ToString(reader["Name"], string.Empty);
                        restaurant.CreatedDate = CustomConverter.ToDateTime(reader["CreatedDate"], DateTime.Now);
                        restaurant.ModifiedDate = CustomConverter.ToDateTime(reader["ModifiedDate"], DateTime.Now);
                    }
                }
            }

            return restaurant;
        }
    }
}
