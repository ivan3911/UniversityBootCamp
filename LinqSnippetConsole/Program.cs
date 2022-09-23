using LinqSnippetConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Snnipets.BasicLinQ();
//Snnipets.LinqNumbers();
//Snnipets.SearchExamples();
//Snnipets.MultipleSelects();
//Snnipets.linqCollections();
Snnipets.SkipTakeLinq();

public class Snnipets {
    static public void BasicLinQ() {

        string[] cars =
            {
            "VW Golf",
            "VW California",
            "Audi A3",
            "Audi A5",
            "Fiat Punto",
            "Seat Ibiza",
            "Seat Leon"
        };


        //1. SELECT * of Cars
        var carList = from car in cars select car;

        //foreach (var car in carList) 
        //{
        //    Console.WriteLine(car);
        //}

        //2 SELECT WHERE cas is Audi (SELECT AUDIs)

        var audiList = from car in cars where car.Contains("Audi") select car;
        //foreach (var audi in audiList)
        //{
        //    Console.WriteLine(audi);
        //}

    }

    
    //NUMBER EXAMPLES
    static public void LinqNumbers() 
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        //Each number multiplied by 3
        //take all numbers, but 9
        //Order number by ascending value

        var processedNumberList =
            numbers
                .Select(num => num * 3)
                .Where(num => num != 9)
                .OrderBy(num => num);

    }

    static public void SearchExamples() 
    {
        List<string> textList = new List<string>
        {
            "a",
            "bx",
            "c",
            "d",
            "e",
            "cj",
            "f",
            "c"
        };

        //1. First of all elements
        var first = textList.First();

        //2. First element that is "c"
        var cText = textList.First(text => text.Equals("c"));

        //3. First element that contains "j"
        var jText = textList.First(text => text.Contains("j"));

        //4. First element that contains "z" or default
        var zText = textList.FirstOrDefault(text => text.Contains("z"));

        //5. Last element that contains "z" or default
        var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));

        //6. Single values
        //var uniqueText = textList.Single();
        //var uniqueorDefaultText = textList.SingleOrDefault(text => text.Contains("j"));

        int[] eventNumber = { 0, 2, 4, 6, 8 };
        int[] otherEventNumbers = { 0, 2, 6 };

        //Obtain { 4, 8 }
        var myEventNumbers = eventNumber.Except(otherEventNumbers);

    }

    static public void MultipleSelects() 
    {
        //SELECT MANY
        string[] myOpinions = 
        {
            "Opinion 1, text 1",
            "Opinion 2, text 2",
            "Opinion 3, text 3",
        };

        var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));

        var enterprises = new[]
        {
            new Enterprise()
            {
                Id=1,
                Name="Enterprise 1",
                Employees = new []
                {
                    new Employee
                    {
                        Id=1,
                        Name="Martin",
                        Email = "martin@imagina.com",
                        Salary= 3000
                    },
                    new Employee
                    {
                        Id=2,
                        Name="Pepe",
                        Email = "pepe@imagina.com",
                        Salary= 1000
                    },
                    new Employee
                    {
                        Id=3,
                        Name="Juanjo",
                        Email = "juanjo@imagina.com",
                        Salary= 2000
                    },
                }
            },
            new Enterprise()
            {
                Id=2,
                Name="Enterprise 2",
                Employees = new []
                {
                    new Employee
                    {
                        Id=4,
                        Name="Ana",
                        Email = "ana@imagina.com",
                        Salary= 3000
                    },
                    new Employee
                    {
                        Id=5,
                        Name="Maria",
                        Email = "maria@imagina.com",
                        Salary= 1500
                    },
                    new Employee
                    {
                        Id=6,
                        Name="Marta",
                        Email = "marta@imagina.com",
                        Salary= 4000
                    },
                }
            }
        };

        //Obtain all employees of all Enterprises

        var empployeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

        //Know if ana list is empty
        bool hasEnterprises = enterprises.Any();

        bool hasEnnployees = enterprises.Any(enterprise => enterprise.Employees.Any());

        //All enterprises at least employee with at least 1000 of Salary
        bool hasEmployeeWithSalaryMoreThanOrEqual1000 =
            enterprises.Any(enterprise =>
                enterprise.Employees.Any(employee => employee.Salary >= 1000));



    }

    static public void linqCollections() 
    {
        var firstList = new List<string>() { "a", "b", "c" };
        var secondList = new List<string>() { "a", "c", "d" };

        //Inner Join
        var commonResult = from element in firstList
                           join secondElement in secondList
                           on element equals secondElement
                           select new { element,secondElement};

        var commonResult2 = firstList.Join(
                            secondList,
                            element => element,
                            secondElement => secondElement,
                            (element, secondElement) => new { element, secondElement }
                            );

        //Outer Join - LEFT
        var leftOuterJoin = from element in firstList
                            join secondElement in secondList
                            on element equals secondElement
                            into temporalList
                            from temporalElement in temporalList.DefaultIfEmpty()
                            where element != temporalElement
                            select new { Element = element };


        var leftOuterJoin2 = from element in firstList
                             from secondElement in secondList.Where(s => s == element).DefaultIfEmpty().Where(x => x != element )
                             select new { Element = element, SecondElement = secondElement };

        //Outer Join -  Right
        var rightOuterJoin = from secondElement in secondList
                             join element in firstList
                             on secondElement equals element
                             into temporalList
                             from temporalElement in temporalList.DefaultIfEmpty()
                             where secondElement != temporalElement
                             select new { Element = secondElement};

        //Union
        var unionList = leftOuterJoin.Union(rightOuterJoin);
             

    }

    static public void SkipTakeLinq() 
    {
        var myList = new[]
        {
            1,2,3,4,5,6,7,8,9,10
        };

        //SKIP
        var skipTwoFirstValues = myList.Skip(2);

        var skipLastTwoValues = myList.SkipLast(2);

        var skipWhileSmallerThan4 = myList.SkipWhile(s => s <= 4);

       //TAKE

        var takeFirstTwoValues = myList.Take(2);
        
        var takeLastTwoValues = myList.TakeLast(2);

        var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4);

        foreach (var element in takeWhileSmallerThan4)
        {
            Console.WriteLine(element);
        }
    }

}
