using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write($"Please, enter your grade (do not include the % symbol): ");
        string grade = Console.ReadLine();
        int grade_percent = int.Parse(grade);
        string grade_letter = "";
        string grade_sign = "";
        int grade_remainder = grade_percent % 10;

        if (grade_percent >= 90)
        {
            grade_letter="A";
        }
        else if (grade_percent >= 80)
        {
            grade_letter="B";
        }
        else if (grade_percent >= 70)
        {
            grade_letter="C";
        }
        else if (grade_percent >= 60)
        {
            grade_letter="D";
        }
        else
        {
            grade_letter="F";
        }
        
        if (grade_letter!="F")
        {
            if (grade_remainder>=7 && grade_letter!="A")
            {
                grade_sign="+";
            }
            else if (grade_remainder<3)
            {
                grade_sign="-";
            }
            else
            {
                grade_sign="";
            }
        }

        grade_letter = grade_letter + grade_sign;

        Console.WriteLine($"Your grade is: {grade_letter}.");
        if (grade_letter=="D" || grade_letter=="D+" ||grade_letter=="D-" ||grade_letter=="F")
        {
            Console.WriteLine($"You did not passed. Please, Don’t let this one result make you doubt your abilities.");
        }
        else
        {
            Console.WriteLine($"Congratulations, you passed. Keep up the good work.");
        }
    }
}