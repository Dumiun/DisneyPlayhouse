using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DisneyPlayhouseLibrary.Services
{
    public class DataAccessService : IDataAccessService
    {
        private readonly IConfiguration configuration;

        public DataAccessService(IConfiguration config)
        {
            configuration = config;
        }

        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName) //T = the model. For example List<T> where T is the model type U is the parameters
        {
            string connectionString = configuration.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);  //change storedProcedure to Text in the command type if I want to change
                return rows.ToList();
            }
        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName) // T is the paramters
        {
            string connectionString = configuration.GetConnectionString(connectionStringName);

            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}