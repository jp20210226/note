using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Linq
{
    #region MyRegion
    //class Program
    //{
    //    public class Student
    //    {
    //        public string First { get; set; }
    //        public string Last { get; set; }
    //        public int ID { get; set; }
    //        public List<int> Scores;
    //    }

    //    // Create a data source by using a collection initializer.
    //    static List<Student> students = new List<Student>
    //    {
    //        new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
    //        new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
    //        new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
    //        new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
    //        new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
    //        new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
    //        new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
    //        new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
    //        new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
    //        new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
    //        new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
    //        new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
    //    };
    //    static void Main(string[] args)
    //    {

    //        var query = from stu in students
    //                    let totle = stu.Scores[0] + stu.Scores[1] + stu.Scores[2] + stu.Scores[3]
    //                    orderby totle
    //                    select totle;
    //        double averageScore = query.Average();
    //        Console.WriteLine("Class average score = {0}", averageScore);

    //        var query1 = from stu in students
    //                     let x = stu.Scores[0] + stu.Scores[1] + stu.Scores[2] + stu.Scores[3]

    //                     where x > averageScore
    //                     select new { id = stu.ID, score = x };

    //        foreach (var item in query1)
    //        {
    //            Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
    //        }

    //        //Random r = new Random() ;
    //        //for (int i = 0; i < 8; i++)
    //        //{
    //        //    Console.WriteLine(r.Next(20, 60));
    //        //}

    //        //List<int> lis = new List<int> { 1, 2, 3, 4, 1, 221 };

    //        //var linq = from li in lis
    //        //           select new { a = li + "1", b =li*2 };

    //        //foreach (var li in linq)
    //        //{
    //        //    Console.Write("{0} ", li);
    //        //}
    //        // Create the data source by using a collection initializer.
    //        // The Student class was defined previously in this topic.
    //        //List<Student> students = new List<Student>()
    //        //{
    //        //    new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores = new List<int>{97, 92, 81, 60}},
    //        //    new Student {First="Claire", Last="O’Donnell", ID=112, Scores = new List<int>{75, 84, 91, 39}},
    //        //    new Student {First="Sven", Last="Mortensen", ID=113, Scores = new List<int>{88, 94, 65, 91}},
    //        //};

    //        //// Create the query.
    //        //var studentsToXML = new XElement("Root",
    //        //    from student in students
    //        //    let scores = string.Join(",", student.Scores)
    //        //    let hah = "达瓦"
    //        //    select new XElement("student",
    //        //               new XElement("First",student.First),
    //        //               new XElement("Last", student.Last),
    //        //               new XElement("Scores",scores),
    //        //               new XElement("dwa", hah)
    //        //            ) // end "student"
    //        //        ); // end "Root"

    //        //// Execute the query.
    //        //Console.WriteLine(studentsToXML);

    //        //// Keep the console open in debug mode.
    //        //Console.WriteLine("Press any key to exit.");


    //        Console.ReadKey();
    //    }
    //}
    #endregion


}
