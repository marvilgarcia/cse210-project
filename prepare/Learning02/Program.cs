using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Sotware Enginner";
        job1._startYear = 2022;
        job1._endYear = 2023;

        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Junior developer";
        job2._startYear = 2023;
        job2._endYear = 2024;


        Resume resume1 = new Resume();
        resume1._name =  "Marvil Garcia";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.Display();







    }
}