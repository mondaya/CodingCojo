using Factories.Movie;
using Microsoft.Extensions.Options;
using Models.Movie;
using movieapi;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Factories.Note{

    public class MovieDBFactory: IFactory<MovieDB>
    {
        
        private readonly IOptions<MySqlOptions> MySqlConfig;

        public MovieDBFactory(IOptions<MySqlOptions> config){
            MySqlConfig = config;
        }

        internal IDbConnection Connection
        {
            get { return new MySqlConnection(MySqlConfig.Value.ConnectionString);}
        }



       public void Add(MovieDB item){
           using(IDbConnection dbConnection = Connection) {
               string r_date = item.releasedAt.ToString("yyyy-MM-dd");
                string Query = $"INSERT INTO `moviedb`  (`title`,`rating`,`releasedAt`,`createdAt`) VALUES('{item.title}','{item.rating}','{r_date}', NOW());";
                dbConnection.Open();
                dbConnection.Execute(Query, item);            
           }

       }

       public List<MovieDB> FindAll(){

            using(IDbConnection dbConnection = Connection) {
                string Query = "SELECT * FROM `moviedb`";
                dbConnection.Open();
                return dbConnection.Query<MovieDB>(Query).ToList();            
           }
       }

       public MovieDB GetLatest()
        {
            using(IDbConnection dbConnection = Connection)
            {
                string Query = "SELECT * FROM moviedb ORDER BY id DESC LIMIT 1";
                dbConnection.Open();
                return dbConnection.QuerySingleOrDefault<MovieDB>(Query);
            }
        }


    }
}