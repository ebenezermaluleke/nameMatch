// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using System.IO;
using System;
using System.Text;

public class NameMatch
{
 
    public int distance(string name1, string name2)
    {
 
        var input1 = name1.Split(' ');
        var input2 = name2.Split(' ');
         return input1.Count(x =>input2.Contains(x));
       
    }

    public double percentage(string name1, string name2)
    {
        if(name1==null || name2 == null)
        {
            return 0.0;
        }else if( name1.Length ==0 || name2.Length == 0)
        {
            return 0.0;
        }else if(name1 == name2)
        {
            return 100;
        }else
        {
            int calc = distance(name1, name2);
            return (1.0- ((double)calc)/((double)Math.Max(name1.Length, name2.Length)));
        }
    
    }



    /*void calcPerc()
     {
         int sum = 0, tempSum=0;

         Console.Write("Enter array length: ");
         int length = Int32.Parse(Console.ReadLine());

         int[] arr = new int[length];

         for (int i = 0; i < length; i++)
         {
             Console.Write("Enter {0} element: ", i);
             arr[i] = Int32.Parse(Console.ReadLine());
         }

         for (int i = 0; i < length - 1; i++)
         {
             tempSum = arr[i];

             for (int j = 0; j < length; j++)
             {
                 tempSum = arr[j];
                 if (tempSum > 0) 
                     sum += tempSum;

             }

         }
         Console.WriteLine("Result is {0}. ", sum);

     }*/





    public static void Main()
    {

        string input;
        Console.WriteLine("Input name 1");
        string name1 = Console.ReadLine();
        // convert input to uppercase to then check the regex
       
        input = name1.ToUpper();
        if (!Regex.Match(name1, "^[a-zA-Z]*$").Success)
        {
            Console.WriteLine("Invalid input");
        }

        Console.WriteLine("Input name 2");
        string name2 = Console.ReadLine();
        input = name2.ToUpper();
        if (!Regex.Match(name2, "^[a-zA-Z]*$").Success)
        {
            Console.WriteLine("Invalid input");
        }


        string str = name1+ " matches " + name2;

        Console.WriteLine("Match name : " + str);
        while (str.Length > 0)
        {
            Console.Write(str[0] + " = ");
            int cal = 0;

            for (int j = 0; j < str.Length; j++)
            {
                if (str[0] == str[j])
                {
                    if (str[0] == ' ')
                    {

                    }
                    else
                    {
                        cal++;
                    }

                }
            }
           
               Console.WriteLine(cal);
               str = str.Replace(str[0].ToString(), string.Empty);
         
           
        }


        // opening a file and read string into array
        string[] lines;
        var list = new List<string>();
        var filestream = new FileStream(@"C:\Users\Ebeneizer\Documents\Projects\C#\GoodAssessment\docs\file.txt", FileMode.Open, FileAccess.Read);
        using (var streamReader = new StreamReader(filestream, Encoding.UTF8))
        {
            string line;
            while((line =  streamReader.ReadLine()) != null){
                list.Add(line);
            }
        }
        lines = list.ToArray();
        
        // count the percentage
        string name = name1;
        string[] iname2 = lines;
        var s = name.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        var res1 = (from string part in iname2
                    select new
                    {
                        list = part,
                        count = part.Split(new char[] { ' ' }).Sum(p => s.Contains(p) ? 1 : 0)
                    }).OrderByDescending(p => p.count).First();
        Console.Write("Percentage ", res1.count);

        /*
        NameMatch dem = new NameMatch();
        double perc = dem.percentage(name1, name2); //calculating the percentage
        Console.WriteLine("Percentage ", perc);*/
        Console.ReadLine();
    }


}