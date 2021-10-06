using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using HangManApi.Models;
using System.Text;

namespace HangManApi
{
    public class DataAccess : IDataAccess
    {
        private readonly string connectionString = @"Data Source=DESKTOP-SL3S0LU\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public List<Actor> GetActors(int? id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT  " +
                    "[actor_id] as ActorId, " +
                    "[first_name] as FirstName, " +
                    "[last_name] as LastName, " +
                    "[last_update] as LastUpdate " +
                    "FROM [sakila].[dbo].[actor]";

                if (id != null)
                {
                    query += $" WHERE actor_id = {id}";
                }

                var result = connection.Query<Actor>(query);

                return result.ToList();
            }
        }

        public List<Film> GetFilms(int? id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT  " +
                    "[film_id] as FilmId, " +
                    "[title] as Title " +
                    "FROM [sakila].[dbo].[film]";

                if (id != null)
                {
                    query += $" WHERE film_id = {id}";
                }

                var result = connection.Query<Film>(query);

                return result.ToList();
            }
        }

        public List<LtAnimal> GetLtAnimals(int? id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT  " +
                    "[animal_id] as LtAnimalId, " +
                    "[name] as Name " +
                    "FROM [UnicodeDatabase].[dbo].[lt_animal]";

                if (id != null)
                {
                    query += $" WHERE animal_id = {id}";
                }

                var result = connection.Query<LtAnimal>(query);

                return result.ToList();
            }
        }

        public List<Country> GetCountries(int? id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT  " +
                    "[country_id] as CountryId, " +
                    "[name] as Name " +
                    "FROM [UnicodeDatabase].[dbo].[countries]";

                if (id != null)
                {
                    query += $" WHERE country_id = {id}";
                }

                var result = connection.Query<Country>(query);

                return result.ToList();
            }
        }

        public void AddRecord(Record record)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("INSERT INTO [UnicodeDatabase].[dbo].[records]");
                stringBuilder.Append("(user_name, user_points)");
                stringBuilder.Append($"VALUES(\'{record.UserName}\', {record.UserPoints})");

                var query = stringBuilder.ToString();
                connection.Execute(query);
            }
        }

        public List<Record> GetRecords(int? id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT TOP(1)" +
                    "[user_name] as UserName, " +
                    "[user_points] as UserPoints " +
                    "FROM [UnicodeDatabase].[dbo].[records]" +
                    "ORDER BY[user_points] DESC";

                if (id != null)
                {
                    query += $" WHERE user_id = {id}";
                }

                var result = connection.Query<Record>(query);

                return result.ToList();
            }
        }
    }
}
