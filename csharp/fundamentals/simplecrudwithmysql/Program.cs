using System;
using System.Collections.Generic;
using DbConnection;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine();
            bool exitFlg = false;
            Read();
            while (!exitFlg)
            {

                Console.WriteLine("Tell me what actions you want to perform: {create,update,delete,done}");

                string action = Console.ReadLine();


                switch (action)
                {
                    case "create":
                        Create();
                        Read();
                        break;
                    case "update":
                        if(Update())
                            Read();
                        break;
                    case "delete":
                        if(Delete())
                            Read();
                        break;
                    case "done":
                        exitFlg = true;
                        break;
                    default:
                        Console.WriteLine("Invalid action - needs to be on of these {create,update,delete,done}");
                        break;
                }
            }

        }

        public static void Read()
        {
            //Placed inside the code block where you want to query the database
            List<Dictionary<string, object>> users = DbConnector.Query("Select * from users");
            //or
            //DbConnector.Execute("Some query with no expected return");
            foreach (Dictionary<string, object> user in users)
            {

                foreach (KeyValuePair<string, object> field in user)
                {
                    Console.WriteLine($"{field.Key}: {field.Value}");
                }
                Console.WriteLine();
            }
        }

        public static User GetUser(int userId)
        {
            //Placed inside the code block where you want to query the database
            List<Dictionary<string, object>> users = DbConnector.Query($"Select * from users where id = {userId}");
            //or
            //DbConnector.Execute("Some query with no expected return");
            if (users.Count > 0)
            {
                User user = new User();
                user.FirstName = users[0]["FirstName"] as string;
                user.LastName = users[0]["LastName"] as string;
                user.FavoriteNumber = (int)users[0]["FavoriteNumber"];
                user.id = (int)users[0]["id"];
                return user;
            }

            return null;
        }

        public static void Create(User user = null)
        {

            if (user == null)
            {
                user = new User();
                Console.WriteLine("First Name:");
                user.FirstName = Console.ReadLine();
                Console.WriteLine("last Name:");
                user.LastName = Console.ReadLine();
                Console.WriteLine("Favorite Number:");
                int num;
                if (Int32.TryParse(Console.ReadLine(), out num))
                    user.FavoriteNumber = num;
                else
                    Console.WriteLine("String could not be parsed.");
            }
            DbConnector.Execute("INSERT INTO `users` (`FirstName`,`LastName`,`FavoriteNumber`) " +
                                 $"VALUES('{user.FirstName}','{user.LastName}',{user.FavoriteNumber});");
        }

        public static bool Delete(int userId = -1)
        {
            if (userId == -1)
            {
                Console.WriteLine("User Id:");
                int num;
                if (Int32.TryParse(Console.ReadLine(), out num))
                    userId = num;
                else
                {
                    Console.WriteLine("String could not be parsed.");
                    return false;
                }
            }
            DbConnector.Execute($"DELETE FROM `users`  WHERE `id` = {userId};");
            return true;
        }

        public static bool Update(int userId = -1)
        {
            User user = null;

            if (userId == -1)
            {

                Console.WriteLine("User Id:");
                int id;
                if (!Int32.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("String could not be parsed.");
                    return false; 
                }
                userId = id;
            }
            user = GetUser(userId);

            if (user != null)
            {
                Console.WriteLine($"First Name[{user.FirstName}]:");
                string fname = Console.ReadLine();
                user.FirstName = fname.Length > 0 ? fname : user.FirstName;

                Console.WriteLine($"last Name[{user.LastName}]:");
                string lname = Console.ReadLine();
                user.LastName = lname.Length > 0 ? lname : user.LastName;

                Console.WriteLine($"Favorite Number:[{user.FavoriteNumber}]");
                int num;
                if (Int32.TryParse(Console.ReadLine(), out num))
                    user.FavoriteNumber = num;
                DbConnector.Execute("UPDATE  `users`  " +
                                $"SET `FirstName` = '{user.FirstName}' , `LastName` = '{user.LastName}', `FavoriteNumber` = {user.FavoriteNumber} " +
                                $"WHERE id = {user.id}");
                return true;
            }
            else{
                Console.WriteLine($"User not found with id:{userId}.");
                return false;
            }




        }
    }
}
