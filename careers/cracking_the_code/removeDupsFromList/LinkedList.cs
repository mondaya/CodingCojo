using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    class LinkedList
    {
        Node head;

        public LinkedList()
        {
            head = null;
        }

        override
        public string ToString()
        {
            var currNode = this.head;
            StringBuilder sb = new StringBuilder();
            while (currNode != null)
            {
                if (sb.Length > 0)
                {
                    sb.Append(',');
                }
                sb.Append(currNode.value);
                currNode = currNode.next;
            }
            return sb.ToString();
        }

        public void Partition2(int x)
        {
            Node head = this.head;
            Node tail = this.head;

            Node node = this.head;

            while (node != null)
            {
                Node next = node.next;
                if (node.value < x)
                {
                    //1* Insert node at head. *1
                    node.next = head;
                    head = node;
                }
                else
                {
                    //Insert node at tail . *1
                    tail.next = node;
                    tail = node;
                }
                node = next;
            }
            tail.next = null;

            //II The head has changed, so we need to return it to the user.
            this.head = head;
        }


        public void Partition(int value)
        {
            Node runner = this.head;
            Node findRunner = this.head;
            while (runner != null)
            {
                if (runner.value >= value)
                {

                    //find min 
                    while (findRunner.next != null)
                    {
                        //swap
                        if (findRunner.next.value < value)
                        {
                            int temp = runner.value;
                            runner.value = findRunner.next.value;
                            findRunner.next.value = temp;
                            //reset find runner

                            break;
                        }
                        findRunner = findRunner.next;
                    }

                    findRunner = runner;

                }
                runner = runner.next;
                findRunner = findRunner.next;
            }
        }

        public bool Parlimdrome()
        {
           Node runner = this.head;

           Stack<int> stack = new Stack<int>();
           int len = 0;

            while (runner != null)
            {
                runner = runner.next;
                len++;
            }

            if (len == 1)
               return true;

            int k = len/2;
            runner = this.head;

            while (runner != null && k > 0)
            {  
                stack.Push(runner.value);
                runner = runner.next;
                k--;
            }           

            if(len % 2  == 1){
               runner = runner.next;
            }
            
            while(runner != null){
                if(runner.value !=  stack.Pop())
                    return false;
                runner = runner.next;
            }
            return true;
            
        }


        public int FindKthToLast(int k)
        {
            Node runner = this.head;
            Node kRunner = this.head;

            while (runner != null && k >= 1)
            {
                runner = runner.next;
                k--;
            }

            if (k == 0)
            {
                while (runner != null)
                {
                    runner = runner.next;
                    kRunner = kRunner.next;
                }
            }
            return kRunner.value;


        }

        public void RemoveFromMiddle(int value)
        {
            Node fastRunner = this.head;
            Node slowRunner = this.head;

            int k = 2;
            while (fastRunner != null && k > 0)
            {
                fastRunner = fastRunner.next;
                k--;
            }

            if (k == 0)
            {
                slowRunner = this.head;

                while (fastRunner != null && slowRunner.next.value != value)
                {
                    fastRunner = fastRunner.next;
                    slowRunner = slowRunner.next;
                }
            }

            if (slowRunner.next.value == value)
            {
                slowRunner.next = slowRunner.next.next;
            }


        }

        public bool RemoveByNodeFromMiddle(int nodeIndex)
        {
            Node runner = this.head;

            int k = nodeIndex;
            while (runner != null && k > 0)
            {
                runner = runner.next;
                k--;
            }

            if (k == 0)
            {

                Node next = runner.next;
                runner.value = next.value;
                runner.next = next.next;
                return true;
            }


            return false;




        }

        public void Add(int value)
        {
            Node neweNode = new Node(value);
            if (this.head == null)
            {
                this.head = neweNode;
            }
            else
            {
                Node runner = this.head;
                while (runner.next != null)
                {
                    runner = runner.next;
                }
                runner.next = neweNode;
            }
        }


        public void removeDuplicates()
        {
            HashSet<int> visited = new HashSet<int>();
            Node currNode = this.head;
            Node prevNode = this.head;

            while (currNode != null)
            {

                if (visited.Contains(currNode.value))
                {
                    prevNode.next = currNode.next;                    


                }
                else
                {
                    visited.Add(currNode.value);
                    prevNode = currNode;
                }

                
                currNode = currNode.next;

            }



        }
    }

}