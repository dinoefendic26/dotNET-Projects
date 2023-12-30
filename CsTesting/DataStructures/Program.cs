using System;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Threading.Tasks;

class Progam
{
    static void Main(string[] args)
    {
        //calculate();
        //utfTest();
        alphabetWithAscii();
        //getNumFromString();
        //binToDec();

        //matrix();

    }

    static void matrix()
    {
        string word = "Follow the white rabbit!";
        for(int i = 0; i < word.Length; i++)
        {
            Console.Write(word[i]);
            Thread.Sleep(150);
        }
    }

    static void loop()
    {
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine("I'm a Criminal");
        }
    }

    static void alphabetWithAscii()
    {   
        //Alphabet from 65 to 90
        int letterNum = 65;

        for(int i = 65; i <= 90; i++)
        {
            char ch = Convert.ToChar(letterNum);
            Console.Write(ch + " ");
            letterNum++;
            Thread.Sleep(100);
        }
    }

    static void getNumFromString()
    {
        
        Console.Write("Enter a name: ");
        string name = Console.ReadLine() ?? "";
        int len = name.Length;
        
        Console.Write("Name in ASCII: ");
        for(int i = 0; i < len; i++)
        {
            int num = Convert.ToInt32(name[i]);
            Console.Write(num + " ");
        }
    }

    static void binToDec()
    {
        Console.Write("Enter a 8-bit binary number: ");
        string binary = Console.ReadLine() ?? "";

        //Check if number is binary
        if(binary.Length < 8){
            Console.WriteLine("Not a 8-bit number!");
        }
        else{
            for(int i = 0; i < binary.Length; i++)
            {
                if(binary[i] == '0' || binary[i] == '1'){
                    continue;
                }
                else{
                    Console.WriteLine("Not a binary number!");
                    break;
                }
            }
            Console.WriteLine(binary);
        }

        //Convert to decimal
        int dec = 0;
        binary = reverseBinary(binary);
        for(int i = 0; i < binary.Length; i++)
        {
            int binDigit = int.Parse(binary[i].ToString());
            Console.WriteLine(i + ": " + binDigit);

            dec = dec + binDigit * ((int)Math.Pow(2, i)); 
        }
        Console.WriteLine("Decimal number: " + dec);
    }

    static string reverseBinary(string bin)
    {
        string binary = "";
        for(int i = bin.Length-1; i >= 0; i--)
        {   
            binary += bin[i];
        }
        return binary;
    }

    static void utfTest()
    {
        string formatedNum;
        int num = 0;
        char cha;
        for(int i = 1; i <= 16; i++)
        {
            for(int j = 1; j <= 8; j++)
            {
                if(num <= 31){
                    formatedNum = num.ToString("D3");
                    Console.Write(formatedNum + ":    ");
                }
                else{
                    formatedNum = num.ToString("D3");
                    cha = Convert.ToChar(num);
                    Console.Write(formatedNum + ": " + cha + "  ");
                }
                num++;
                Thread.Sleep(500);
            }
            Console.WriteLine();
        }
    }

    static void calculate()
    {
        int i;
        int number = 1;
        int sum = 0;

        for(i = 1; i <= 7; i++)
        {
            Console.WriteLine(number);
            sum = sum + number;
            number = number + number;
        }

        Console.Write("The sum of all numbers: " + sum);
    }

    static void sync()
    {
        
    }
}
