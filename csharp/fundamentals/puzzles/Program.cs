using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
   
    public class Program
    {  
        private static Random RAND = new Random();
        private static string [] TOSSED = {"Heads","Tails"}; 
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RandomArray();
            Console.WriteLine(TossMultipleCoins(1000));
            string [] arr = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            PrintValuesInArr(Names(arr));
        }

        public static string[] Names(string[] arr){

            PrintValuesInArr(arr);
            Shuffle(arr);
            PrintValuesInArr(arr);
            return getNamesWithLenGT(arr, 5);
        }

        private static string[] getNamesWithLenGT(string[] arr, int val){
            List<string> matched = new List<string>();
            foreach(string name in arr){
                if( name.Length > val)
                    matched.Add(name);
            }
            return matched.ToArray();
        }

        private static void Shuffle<T>(T [] arr){
            for(int i = 0;  i < arr.Length; i++){
                int randIndex = RAND.Next(i, arr.Length);
                T temp = arr[randIndex];
                arr[randIndex] =  arr[i];
                arr[i] = temp;

            }
        }


        private static string TossCoin(){
                       
            Console.WriteLine("Tossing a Coin!");
            int toss =  RAND.Next(0,2);
            Console.WriteLine("Tossed: {0}", TOSSED[toss]);            
            return TOSSED[toss];
        }

        public static double TossMultipleCoins(int num){
            double ratio = 0.0;
            int numHeads = 0;
            if(num > 0){
                for(int i = 1; i <= num; i++){
                    if(TossCoin() == TOSSED[0])
                        numHeads += 1;
                }
                ratio = (double)numHeads/(double)num;
            }

            return ratio;
        }

        public static int[] RandomArray(){
            int[] array = new int[10];
            Random rand = new Random();
            for(int i = 0; i < array.Length; i++){
                array[i] = rand.Next(5, 25+1);
            }
            printMaxMinSumAvgOfArr(array);
            return array;
        }

         public static void printMaxMinSumAvgOfArr(int[] myArray){  

            int sum = 0;
            int max = 0;
                      
            Console.WriteLine("My Array");
            PrintValuesInArr(myArray);
            int min = myArray[0];
            max = myArray[0];
            sum = 0;
            for(int i = 0; i < myArray.Length; i++){
                
                if (myArray[i] > max)
                       max = myArray[i];
                if(myArray[i] < min)
                       min = myArray[i];                 
                sum += myArray[i];
                
            }
           Console.WriteLine($"Averge: {sum/(float)myArray.Length}"); 
           Console.WriteLine($"Max: {max}");  
           Console.WriteLine($"Max: {min}");  
           Console.WriteLine($"Sum: {sum}");  
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

    }
}
