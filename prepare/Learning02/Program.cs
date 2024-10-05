using System;

class Program
{
    static void Main(string[] args)
    {
        Resume resume = new();

        resume._name = "John Person";

        Job job1 = new();
        job1._company = "Company A";
        job1._jobTitle = "Superstar";
        job1._startYear = 2020;
        job1._endYear = 2021;
        resume._jobs.Add(job1);

        Job job2 = new();
        job2._company = "Company B";
        job2._jobTitle = "Supermodel";
        job2._startYear = 2022;
        job2._endYear = 2023;
        resume._jobs.Add(job2);

        resume.DisplayResume();
    }
}