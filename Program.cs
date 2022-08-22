/*
 * What is Regex?
 * A regular expression (regex) is a sequence of characters that specifies a search pattern in text.It can also be used for
 * input validation by speciying a pattern to match.
 * 
 * Why do we need Regex?
 * Regex is used where user input needs validation,i,e if the date,email address,website address or existence of a patricular string on a page
 * can be validated by using a single line of code.Reusability of the code(regex pattern) is possible.
 * 
 * How to use regex and which library to include?
 * We need to first include the library - System.Text.RegularExpressions in the program.Create a instance of the Regex class and using
 * this regex instance, the methods belonging to regex class can be used.
 * 
 * Program Description:
 * In this program I have used the a menu to search for a string in a text,validate email address,validate a website
 * and validate date(most tricky).
 
*/
using System;
using System.Text.RegularExpressions;// C# has built-in library for working with regular expressions
using System.IO;

namespace Regex_Search
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string choice,ans;
            //Perform the loop atleast once
            do
            {
                Console.Clear();
                Console.WriteLine("Regex Program");
                Console.WriteLine("__________________________");
                Console.WriteLine("1.Search text in the file");
                Console.WriteLine("2.Validate Email");
                Console.WriteLine("3.Validate Website");
                Console.WriteLine("4.Validate Date");
                Console.WriteLine();
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();
                //calling the method Regex_Search
                if (choice == "1") Regex_Search();
                //calling the method Validate_Email
                else if (choice == "2") Validate_Email();
                //calling the method Validate_Website
                else if (choice == "3") Validate_Website();
                //calling the method Validate_Date
                else if (choice == "4") Validate_Date();

                Console.Write("Do you wish to continue again? ");
                ans = Console.ReadLine();

            } while (ans == "y");

            
        }

       public static void Regex_Search()
        {
            // In this method the user first enters the text and then the second input is the string
            // which the users wants to search in the text
            
            Console.Write("Enter the text where search will be performed: ");
            string long_text = Console.ReadLine();
            
            Console.Write("Enter the string to be searched in the above text: ");
            string str = Console.ReadLine();
           
            Regex regex = new Regex(str);
            // Match for the occurance of string str in long_text
            Match match = regex.Match(long_text);

 
            //The Match Success property returns a boolean value indicating whether the match was successful or not
            if (match.Success)
            {
                
                Console.WriteLine("The string exists in the text");
                
            }
            else
            {
                Console.WriteLine("The string does NOT exist in the text");
            }
        }

       public static void Validate_Website()
       {
            Console.Write("Enter the website address/URL to be validated:");
            string website = Console.ReadLine();
            Regex WebsiteRegex = new Regex(website);

            //This the regex pattern which we need to use for checking a website address
            WebsiteRegex = new Regex(@"^(http:\/\/|https:\/\/)?(www.)?([a-zA-Z0-9]+).[a-zA-Z0-9]*.[‌​a-z]{3}\.([a-z]+)?$");
            //                              Group1             Group2   Group3        Group4       Group5      Group6
            
            //Group 1:Check if the input(case sensitive) is either http or https, note the | symbol which represents OR.
            //  \    :Check for the character following it.Here it is //(appears twice)
            //Group 2:Check if the input(case sensitive) is www.
            // ?     :Matches the previous character once
            //Group 3:Check if the input is betweek A to Z or a to z or 0 to 9
            // +     :Matches the previous character once or more than one time
            //Group 4:Check if the input is betweek A to Z or a to z or 0 to 9
            //Group 5:Check if the input is betweek a to z only and the maximum length is 3( can be .com,.dk.in
            //        but .next .gove is not valid)
            // ^     :Checks for the starting position
            // $     :Checks for the ending position

            //IsMatch finds if the input string(website) matches the pattern mentioned in WebsiteRegex
            if (WebsiteRegex.IsMatch(website))
            {
                Console.WriteLine("This is a valid website address.");
            }
            else
            {
                Console.WriteLine("This is a NOT a valid website address.");
            }
        }

        public static void Validate_Email()
        {
            Console.Write("Enter the email address to be validated:");
            string email = Console.ReadLine();
            Regex EmailRegex = new Regex(email);
            //This the regex pattern which we need to use for checking a email address
            EmailRegex = new Regex("^[a-zA-Z0-9]+[@]+[a-zA-Z]+[.][a-zA-z]{2,3}$");
            //                      Group1            Group2      Group3

            //Group 1: Check if the input is betweek A to Z or a to z or 0 to 9
            // +     :Matches the previous character once or more than one time
            //[@]    :Check if the @ exists
            //Group 2:Check if the input is betweek A to Z or a to z 

            //Group 3:Check if the input is betweek A to Z or a to z 
            // +     :Matches the previous character once or more than one time
            //[.]    :Check if . exists
            //{2,3}  :Check if the minimum length is 2 and maximum lenght is 3 characters
            // ^     :Checks for the starting position
            // $     :Checks for the ending position

            EmailRegex.IsMatch(email);
            //IsMatch finds if the input string(email) matches the pattern mentioned in EmailRegex
            if (EmailRegex.IsMatch(email))
            {
                Console.WriteLine("This is a valid email.");
            }
            else
            {
                Console.WriteLine("This is a NOT a valid email.");
            }
        }

        public static void Validate_Date()
        {
            Console.Write("Enter the date dd/mm/yyyy to be validated:");
            string date = Console.ReadLine();
            Regex DateRegex = new Regex(date);
            //This the regex pattern which we need to use for checking a date dd/mm/yyyy 
            //DateRegex = new Regex("^[0-9]{1,2}\\/[0-9]{1,2}\\/[0-9]{4}$");

            DateRegex = new Regex("[0-3]?[0-9]\\/[01]?[0-9]\\/?[0-2][0-9][0-9][0-9]");
            //                      Group1         Group2         Group3
            //
            //Group 1:Check if the first digit 'dd' input is 0 or 1 or 2 to 3 
            // ?     :Matches the previous character once
            //[0-9]  :Check if the second didgit in the 'dd' is between 0 to 9

            //Group 2:Check if the first digit 'mm' input is 0 or 1 
            //[0-9]  :Check if the second didgit in the 'mm' is between 0 to 9

            //Group 3:Check if the first digit 'yyyy' input is 0 or 1 or 2 
            //[0-9]  :Check if the second,third and fourth digit in the 'yyyy' is between 0 to 9
            // \\/    :Check if / exists
            
            DateRegex.IsMatch(date);

            if (DateRegex.IsMatch(date))
            {
                Console.WriteLine("This is a valid date.");
            }
            else
            {
                Console.WriteLine("This is a definately not a valid date.");
            }
        }

    }
}
