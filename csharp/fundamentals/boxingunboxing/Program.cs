using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<object>myList = new List<object>();
            myList.Add(7);
            myList.Add(28);
            myList.Add(-1);
            myList.Add(true);
            myList.Add("chair");
            int sum = 0;

            foreach( Object thing in myList){

                 Console.WriteLine(thing);
               

                 if(thing is int){
                    sum += (int)thing;
                 }

                 
            }
            Console.WriteLine($"sum of init in myList:{sum}");

        }

    }
}
