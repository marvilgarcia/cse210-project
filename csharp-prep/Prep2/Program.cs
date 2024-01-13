using System;
using System.Security.Cryptography.X509Certificates;


Console.Write("What is your percentage score? ");
string score = Console.ReadLine();

int x =  int.Parse(score);

if (x >= 90)
{
    Console.WriteLine("Your letter grade is A");
}
else if (x < 90 && x >= 80)
{
    Console.WriteLine("Your letter grade is B");

}
else if (x < 80 && x >= 70)
{
    Console.WriteLine("Your letter grade is C");
}
else if(x < 70 && x >= 60)
{
    Console.WriteLine("Your letter grade is D");
    
}
else 
{
    Console.WriteLine("Your letter grade is F");
}