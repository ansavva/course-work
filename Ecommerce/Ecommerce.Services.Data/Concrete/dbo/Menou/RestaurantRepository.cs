using Ecommerce.Services.Core.Logic.Concrete;
using Ecommerce.Services.Core.Logic.Contracts;
using Ecommerce.Services.Core.Model;
using Ecommerce.Services.Data.Contracts;
using Ecommerce.Services.Data.Contracts.dbo.Ecommerce;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Ecommerce.Services.Data.Concrete.dbo.Ecommerce
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly IConfigurationSettings _configurationSettings;
        private readonly ISqlFileReaderEngine _fileReader;

        public RestaurantRepository(IConfigurationSettings configurationSettings, ISqlFileReaderEngine fileReader)
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

            using (SqlConnection connection = new SqlConnection(_configurationSettings.Settings("EcommerceConnectionString")))
            {
                using (SqlCommand sqlCommand = new SqlCommand(_fileReader.GetSqlCode("ReadRestaurantById", "Ecommerce")))
                {
                    connection.Open();
                    sqlCommand.Connection = connection;
                    sqlCommand.Parameters.Add("@RestaurantId", SqlDbType.Int);
                    sqlCommand.Parameters["@RestaurantId"].Value = restaurantId;

                    using (IDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            restaurant.Id = CustomConverter.ToInt(reader["Id"], -1);
                            restaurant.Name = CustomConverter.ToString(reader["Name"], string.Empty);
                            restaurant.CreatedDate = CustomConverter.ToDateTime(reader["CreatedDate"], DateTime.Now);
                            restaurant.ModifiedDate = CustomConverter.ToDateTime(reader["ModifiedDate"], DateTime.Now);
                        }
                    }
                }
            }

            return restaurant;
        }
    }
}
