using System;

class Program
{
    static void Main(string[] args)
    {
        // Unless a namespace is specified, all classes in the same project will be made available to each other.
        
        // If they are in different namespaces, you will need to use the "using" directive to access them. OR
        // you can use the fully qualified name of the class.
        Job job1 = new Job();
        Job job2 = new Job();

        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2019;
        job1._endYear = 2022;

        job2._company = "Apple";
        job2._jobTitle = "Manager";
        job2._startYear = 2022;
        job2._endYear = 2023;
        
        Resume resume = new Resume();
        resume._name = "Allison Rose";

        // There is a distinct difference between Arrays and Lists. An Array can be thought of
        // as a fixed-size or simple list. A List is a dynamic array that can grow or shrink in size.

        // A List is constructed with { } instead of [ ] which is used for Arrays.
        resume._jobs = new List<Job> { job1, job2 };

        resume.Display();
    }
}