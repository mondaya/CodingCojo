using System;
using System.Collections.Generic;

namespace ConsoleApplication
{  
    
    public class Program
    {
        private static string[] NAMES = {"Tim","Martin","Nikki","Sara"};        
        private static List<string> iceCreamFalvors = new List<string>();
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine();
            ThreeBasicArrays();
            Console.WriteLine();
            MultiplicationTable();
            Console.WriteLine();
            ListFalvors();
            Console.WriteLine();
            UserInfoDictionary();
            

        }
        
        public static void UserInfoDictionary(){
            //depends on ListFalvors function to be called frist
            Random rand = new Random();
            Dictionary<string,string>usersFalvor = new Dictionary<string,string>();
            int falvorSize = iceCreamFalvors.Count;
            foreach(string name in NAMES){
                usersFalvor.Add(name, iceCreamFalvors[rand.Next(0, falvorSize)]);
            }
            Console.WriteLine("Users Ice Falvors");
            foreach(KeyValuePair<string,string> entry in usersFalvor){
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }

        }

        public static void ListFalvors(){

           /* Create a list of Ice Cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
           Output the length of this list after building itOutput the third flavor in the list, then remove this value.
            Output the new length of the list (Note it should just be one less~)*/
            
            iceCreamFalvors.Add("Vanilla");
            iceCreamFalvors.Add("Straw Berry");
            iceCreamFalvors.Add("Mint Chocolate");
            iceCreamFalvors.Add("Cookie Dough");
            iceCreamFalvors.Add("Rasberry");

            Console.WriteLine($"Ice Cream Flavors of len {iceCreamFalvors.Count}");           
            Console.WriteLine($"Thrid Flavor is {iceCreamFalvors[2]}");
            Console.WriteLine("removing the Thrid Flavor");
            iceCreamFalvors.RemoveAt(2);
            Console.WriteLine($"Ice Cream Flavors of len {iceCreamFalvors.Count}");
            

        }
        public static void MultiplicationTable(){
            /* With the values 1-10, use code to generate a multiplication*/
             int [][] multiArr =  Build10by10MultiplicationTbl();
             PrintValuesInMultiArr2d(multiArr);
        }
   
        public static void ThreeBasicArrays(){
          /* Create an array to hold integer values 0 through 9 Create an array of the names "Tim", "Martin", "Nikki", & "Sara" 
           Create an array of length 10 that alternates between true and false values, starting with true*/
           var ARRAY_LEN  = 10;
           int [] integerArr = new int[ARRAY_LEN];                                  
           for(var i = 0; i < ARRAY_LEN; i++)
           {
               integerArr[i] = i;
           }
           PrintValuesInArr(integerArr);          
           PrintValuesInArr(NAMES);
           bool[] trueFalse = new bool[ARRAY_LEN];           
           for(var i = 0; i < ARRAY_LEN; i++){

               if(i == 0){
                   trueFalse[i] = true;
               }
               else
               {
                   trueFalse[i] = !trueFalse[i-1];
               }
           }
           PrintValuesInArr(trueFalse);
        }



        private static int[][] Build10by10MultiplicationTbl(){
            int[][] multiarr = new int[10][];

            for(int row = 0;  row < 10; row++){
                     multiarr[row] = new int[10];
            }

            for(int col = 0; col < 10; col++){
                    int col_value = col + 1;
                for(int row = 0;  row < 10; row++){
                    int row_vlaue = row + 1;
                    multiarr[row][col] = row_vlaue  * col_value;
                }
            }
            return multiarr;
        }

        private static void PrintValuesInArr<T>( T [] array){
           Console.Write("[");
           for(var i = 0; i < array.Length; i++)
           {
                if(i != 0)
                    Console.Write(",");
                 Console.Write(array[i]);
           }
           Console.Write("]");
           Console.WriteLine();
        }

        private static void PrintValuesInMultiArr2d<T>( T [][] multiarray){
           for(var i = 0; i < multiarray.Length; i++)
           {
                PrintValuesInArr(multiarray[i]);
           }
          
        }
    }
}
