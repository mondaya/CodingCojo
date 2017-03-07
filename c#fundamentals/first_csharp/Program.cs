using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //fizzBuzz();
            //fizzBuzz_no_mod();
            //fizzBuzz_rand_10();
            divs3or5only();
        }
        public static void divs3or5only()
        {

          for(int i =1; i <= 100; i++){

              if(i%15==0){
                 continue;
              }
              else if (i%3==0){
                  Console.WriteLine(i);
              }
              else if(i%5==0){
                  Console.WriteLine(i);
              }
          }  
        }

        public static void fizzBuzz()
        {

          for(int i =1; i <= 100; i++){

              if(i%15==0){
                 Console.WriteLine(i + " FizzBuzz");
              }
              else if (i%3==0){
                  Console.WriteLine(i + " Fizz");
              }
              else if(i%5==0){
                  Console.WriteLine(i+ " Buzz");
              }
          }  
        }

        public static void prins1To255(){
             for(int i =1; i <= 100; i++)
                 Console.WriteLine(i);      
        }


        public static void fizzBuzz_no_mod(){
            int fizz = 3;
            int buzz = 5;
            int fizzbuzz = 15;

            for(int i = 1; i<=100; i++){
                fizz--;
                buzz--;
                fizzbuzz--;

                if(fizzbuzz == 0){
                     Console.WriteLine(i + " FizzBuzz");
                     fizzbuzz = 15;
                     fizz = 3;
                     buzz= 5;
                }
                
                if(fizz == 0){
                    Console.WriteLine(i + " Fizz");
                    fizz = 3;
                } 

                if(buzz ==  0){
                   Console.WriteLine(i+ " Buzz");
                   buzz = 5; 
                }
                
            }
        }

        public static void fizzBuzz_rand_10(){
            Random rand = new Random();
            for(int i = 1; i <=10;  i++){
                int rand_value = rand.Next(1, 100);
                if(rand_value%15==0){
                 Console.WriteLine(rand_value + " FizzBuzz");
              }
              else if (rand_value%3==0){
                  Console.WriteLine(rand_value + " Fizz");
              }
              else if(rand_value%5==0){
                  Console.WriteLine(rand_value+ " Buzz");
              }
            }
        }
    }
}
