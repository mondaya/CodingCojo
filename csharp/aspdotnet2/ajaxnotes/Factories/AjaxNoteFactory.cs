using System.Data;
using Models.Note;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Factories.Note{

    public class AjaxNoteFactory: IFactory<AjaxNote>
    {
        private string connectionString;

        public AjaxNoteFactory(){
            connectionString =   "server=localhost;userId=root;password=root;port=8889;database=consoledb;SslMode=None";
        }

       internal IDbConnection Connection
        {

           get { return new MySqlConnection(connectionString);}
       }

       public void Add(AjaxNote item){
           using(IDbConnection dbConnection = Connection) {
                string Query = $"INSERT INTO `ajaxnote`  (`title`,`description`,`CreatedAt`,`UpdatedAt`) VALUES('{item.title}','{item.description}', NOW(),NOW());";
                dbConnection.Open();
                dbConnection.Execute(Query, item);            
           }

       }

       public IEnumerable<AjaxNote> FindAll(){

            using(IDbConnection dbConnection = Connection) {
                string Query = "SELECT * FROM `ajaxnote` ORDER BY `CreatedAt` DESC";
                dbConnection.Open();
                return dbConnection.Query<AjaxNote>(Query);            
           }
       }

       public AjaxNote GetQuoteById(int Id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string Query = $"SELECT * FROM `ajaxnote` WHERE id = {Id} LIMIT 1";
                dbConnection.Open();
                return dbConnection.Query<AjaxNote>(Query).First();
            }
        }

        public void UpdateQuote(AjaxNote item)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string Query = "UPDATE `ajaxnote` SET title = @title, description = @description WHERE id = @id";
                dbConnection.Open();
                dbConnection.Execute(Query, item);
            }
        }

        public void DeleteQuote(int Id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string Query = $"DELETE FROM `ajaxnote` WHERE id = {Id}";
                dbConnection.Open();
                dbConnection.Execute(Query);
            }
        }


    }
}