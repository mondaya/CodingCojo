using System;

namespace ConsoleApplication
{
    public class Program
    {
        static string function(string inputvalue)
        {
            char[] myarray = inputvalue.ToCharArray();
            if (myarray.Length >= 1)
            {
                if (char.IsLower(myarray[0]))
                {
                    myarray[0] = char.ToUpper(myarray[0]);
                }
            }

            for (int i = 1; i < myarray.Length; i++)
            {
                if (myarray[i] == ' ')
                {
                    if (char.IsLower(myarray[0]))
                    {
                        myarray[0] = char.ToUpper(myarray[i]);
                    }
                }
            }

            return new string(myarray);
        }

    public static void Main()
    {
        string inputstring  = "monday ayewa";
	    Console.WriteLine(function(inputstring));

        Console.WriteLine($"test_with_empty_string : {test_with_empty_string()}");
        Console.WriteLine($"test_with_first_letter_lowered : {test_with_first_letter_lowered()}");
        Console.WriteLine($"test_stablilty : {test_stablilty()}");
    }

    static bool test_with_empty_string(){
        string inputstring  = "";
	    string val = function(inputstring);
        return val.Length == 0;
    }

    
    static bool test_with_first_letter_lowered(){
        string inputstring  = "monday Ayewa";
	    string val = function(inputstring);
        return val.CompareTo("Monday Ayewa")  == 0;
    }

    static bool test_stablilty(){
        string inputstring  = "Monday Ayewa";
	    string val = function(inputstring);
        return inputstring.CompareTo("Monday Ayewa")  == 0;
    }


    

    }
}
