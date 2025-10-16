

// dd/mm/yyyy   =>   dd(int)[01-31]/ month(int)[01-12]/ year(int)[0001-9999]

using System.Collections.ObjectModel;

Date d1 = new Date(2000);
Console.WriteLine(d1);  

Date d2 = new Date(29, 2, 2024);
Console.WriteLine(d2); 



public class Date

{
    private static readonly int[] DaysToMonths365 = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    private static readonly int[] DaysToMonths366 = { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    private readonly int day = 01;
    private readonly int month = 01;
    private readonly int year = 01;

    //<AccseeModifier> <TypeName>(<Parameter list>){ series of statment }
    
    public Date(int day, int month, int year) // constructor
    {
        var isLeap = year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);

        if (year >= 1 && year <= 9999 && month >= 1 && month <= 12) 
        {
            int[] days= isLeap ? DaysToMonths366 : DaysToMonths365;
            if (day >= 1 && day <= days[month])
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid date provided.");
            }
        }
        else
        {
            throw new ArgumentOutOfRangeException("Invalid date provided.");
        }

    }

    public Date(int year) : this(01, 01, year)
    {

    }
    public Date(int month, int year) : this(01, month, year)
    {

    }
    public string GetDate()
    {
        return $"{this.day.ToString().PadLeft(2, '0')}/{this.month.ToString().PadLeft(2, '0')}/{this.year.ToString().PadLeft(4, '0')}";
    }
    public override string ToString() => GetDate();

}


