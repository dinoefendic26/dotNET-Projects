using System;

class Program
{

    static void Main(string[] args)
    {
        Console.Write("Enter a binary number: ");
        string binaryInput = Console.ReadLine();

        int decimalResult = BinaryToDecimal(binaryInput);
        Console.WriteLine($"Decimal equivalent: {decimalResult}");

    }

    static int BinaryToDecimal(string binary)
    {
        int decimalResult = 0;

        for(int i = binary.Length - 1; i >= 0; i--)
        {
            int bit = int.Parse(binary[i].ToString());

            int power = binary.Length - 1 - i;
            int contribution = bit * (int)Math.Pow(2, power);

            decimalResult += contribution;
        }

        return decimalResult;
    }
}
