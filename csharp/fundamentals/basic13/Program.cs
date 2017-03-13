using System;
using System.Collections.Generic;


namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            print1To255();
            printoOdds1To255ListOfOdds();
            sum1To255();
            int[] myArray = {1,3,5,7,9,13};   
            printMaxValOfArr(myArray);           
            printAvgOfArr(myArray);       

            Console.WriteLine("greater than 4");           
            printGTYValues(myArray, 4);        

            int[] myArray1 = {1, 5, 10, -2};
            PrintValuesInArr(myArray1);
            printMyArrayDoubled(myArray1);           
            

            int[] myArray2 = {1, 5, 10, -2};
            printPositveWithNegReset(myArray2);
           

            int[] myArray3 = {1, 5, 10, -2};
            printMaxMinSumAvgOfArr(myArray3);


            int[] myArray4 = {1, 5, 10, 7, -2};

            Console.WriteLine("My Array4");
            PrintValuesInArr(myArray4);
            for(int i = 1; i < myArray4.Length; i++){               
               myArray4[i-1] = myArray4[i];
                
            }
            myArray4[myArray4.Length - 1] = 0;
            PrintValuesInArr(myArray4);

            object[] myArray5 = {-1, -3, 2};

            Console.WriteLine("My Array5");
            PrintValuesInArr(myArray5);            
            for(int i = 0; i < myArray5.Length; i++){ 

                if ( myArray5[i]  is int && (int)myArray5[i] < 0 )
                        myArray5[i] = "Dojo";         
            }
            PrintValuesInArr(myArray5); 
        }

        public static void print1To255(){
             Console.Write("[");
            for(int i = 1; i <=255; i++){
                if (i > 1)
                    Console.Write(",");
                Console.Write(i);
            }
            Console.WriteLine("]");
        }

        public static void printoOdds1To255ListOfOdds(){
            Console.WriteLine("odds");
            Console.Write("[");
            List<int>odds = new List<int>();
            for(int i = 1; i <=255; i++){
                
                if(i%2 == 1){
                    if (i > 1)
                        Console.Write(",");                    
                    Console.Write(i);
                    odds.Add(i);
                }
            }
            Console.WriteLine("]");

            Console.WriteLine("odds list");
  
            PrintValuesInArr(odds.ToArray());

        }


        public static void sum1To255(){
            int sum = 0; 
            Console.WriteLine("sum");           
            for(int i = 0; i <=255; i++){
                sum += i;
                Console.WriteLine($"New number: {i} Sum: {sum}");               
            }
        }

        public static void printMaxValOfArr(int [] myArray){

            Console.WriteLine("My Array");
            PrintValuesInArr(myArray);
            Console.WriteLine("Max in My Array");
            int max = myArray[0];
            for(int i = 1; i < myArray.Length; i++){
                
                if (myArray[i] > max)
                       max = myArray[i];                   
                             
            }
            Console.WriteLine(max);
        }

        public static void printAvgOfArr(int [] myArray){
            int sum = 0;           
            Console.WriteLine("Avrage of My Array");
            sum = 0; 
            int average = myArray[0];
            for(int i = 1; i < myArray.Length; i++){
                
                sum += myArray[i];                         
            }
            Console.WriteLine(sum/(float)myArray.Length);
        }

        public static void printGTYValues(int [] myArray, int Y){
           
            List<int>gteY = new List<int>();
            
            for(int i = 0; i < myArray.Length; i++){
                  if (myArray[i] > Y)
                    gteY.Add(myArray[i]);                
            }
            PrintValuesInArr(gteY.ToArray());
        }

        public static void printMyArrayDoubled(int [] myArray){
             Console.WriteLine("My Array");
            PrintValuesInArr(myArray);
            for(int i = 0; i < myArray.Length; i++){                
                myArray[i] *= myArray[i];          
            }
            PrintValuesInArr(myArray);
        }

        public static void printMaxMinSumAvgOfArr(int [] myArray){  

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


        public static void printPositveWithNegReset(int[] myArray){
             Console.WriteLine("My Array");
            PrintValuesInArr(myArray);
            for(int i = 0; i < myArray.Length; i++){
                if(myArray[i] < 0)
                     myArray[i] = 0;       
            }
            PrintValuesInArr(myArray);
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




