using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            dups_test1();
            dups_test2();
            dups_test3();
            dups_test4();
            kth_test(3);
            kth_test(6);
            kth_test(16);
            kth_test(10);
            kth_test(1);
            int [] values = {1,2,3,4,10,6,7,10,2,15,4,16};
            removeFromMiddle(values,7);
            removeFromMiddle(values,10);
            removeByNodeFromMiddle(values,6);
            partition(values, 5);
            partition(values, 5);
            palindrome();
            

        }

        public static void palindrome(){
             int [] values = {1,2,2,1};

             Console.WriteLine("Palindrome");

            LinkedList iList = new LinkedList();

            for(int entry  = 0; entry < values.Length; entry++){
                iList.Add(values[entry]);
            }

            Console.WriteLine(iList);      

            Console.WriteLine(iList.Parlimdrome());
        }



        public static void partition(int [] values, int value){            

             Console.WriteLine($"{value} as partition");

            LinkedList iList = new LinkedList();

            for(int entry  = 0; entry < values.Length; entry++){
                iList.Add(values[entry]);
            }

            Console.WriteLine(iList);      
            iList.Partition(value);
            Console.WriteLine(iList);
        }

        public static void partition2(int [] values, int value){            

             Console.WriteLine($"{value} as partition");

            LinkedList iList = new LinkedList();

            for(int entry  = 0; entry < values.Length; entry++){
                iList.Add(values[entry]);
            }

            Console.WriteLine(iList);      
            iList.Partition2(value);
            Console.WriteLine(iList);
        }


        public static void removeFromMiddle(int [] values, int value){            

             Console.WriteLine($"{value} from midlde");

            LinkedList iList = new LinkedList();

            for(int entry  = 0; entry < values.Length; entry++){
                iList.Add(values[entry]);
            }

            Console.WriteLine(iList);      
            iList.RemoveFromMiddle(value);
            Console.WriteLine(iList);
        }

         public static void removeByNodeFromMiddle(int [] values, int nodeIndex){            

             Console.WriteLine($"{values[nodeIndex]} from midlde By Node");

            LinkedList iList = new LinkedList();

            for(int entry  = 0; entry < values.Length; entry++){
                iList.Add(values[entry]);
            }

            Console.WriteLine(iList);      
            iList.RemoveByNodeFromMiddle(nodeIndex);
            Console.WriteLine(iList);
        }
          public static void kth_test(int k){
             int [] values = {1,2,3,4,5,6,7,10,11,15,16,17};

             Console.WriteLine($"{k} from last");

            LinkedList iList = new LinkedList();

            for(int entry  = 0; entry < values.Length; entry++){
                iList.Add(values[entry]);
            }

            Console.WriteLine(iList);      

            Console.WriteLine(iList.FindKthToLast(k));
        }


        public static void dups_test1(){
            Console.WriteLine("Full List");

            int [] values = {0,3,4,6,4,8,10,10,3,4,5,8,9,0,6,6,6,6,6,11,15,40,3,10};

            LinkedList iList = new LinkedList();

            for(int entry  = 0; entry < values.Length; entry++){
                iList.Add(values[entry]);
            }

            Console.WriteLine(iList);

            iList.removeDuplicates();

            Console.WriteLine(iList);
        }


        public static void dups_test2(){
             int [] values = {};

             Console.WriteLine("Empty List");

            LinkedList iList = new LinkedList();

            for(int entry  = 0; entry < values.Length; entry++){
                iList.Add(values[entry]);
            }

            Console.WriteLine(iList);

            iList.removeDuplicates();

            Console.WriteLine(iList);
        }


        public static void dups_test3(){
             int [] values = {1,2,3,4,5,6,7};

             Console.WriteLine("No Dups");

            LinkedList iList = new LinkedList();

            for(int entry  = 0; entry < values.Length; entry++){
                iList.Add(values[entry]);
            }

            Console.WriteLine(iList);

            iList.removeDuplicates();

            Console.WriteLine(iList);
        }


        public static void dups_test4(){
             int [] values = {1};

             Console.WriteLine("One item");

            LinkedList iList = new LinkedList();

            for(int entry  = 0; entry < values.Length; entry++){
                iList.Add(values[entry]);
            }

            Console.WriteLine(iList);

            iList.removeDuplicates();

            Console.WriteLine(iList);
        }
    }
    

     
}
