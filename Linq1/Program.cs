using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq1
{
    internal class Program
    {

        /*
         LINQ (Language Integrated Query) is a feature in C# that allows you to query data collections 
         (like arrays, lists, or databases) using a declarative syntax similar to SQL.


         */

        static void Main(string[] args)
        {

            //Ex1
            /* string[] names = new string[] { "Osama", "Ahmed", "Omar" };

             var query = from name in names
                         orderby name ascending
                         select name;

             foreach (var i in names)
                 Console.WriteLine(i);*/


            //----------------
            //Ex2

            /*int[] numbers = new int[] {1,2,3,4,5,6,7,8,9 };

            OddNumbers(numbers);*/

            //====================================================================================
            //Linq University Manager 
            UniversityManager um = new UniversityManager();


            //Filtring
            um.MaleStudent();

            um.FmaleStudent();

            um.SortStudentByAge();

            um.AllStudentFromAPU();

            um.StudentAndUniversityNameCollection();

            //Sotring
            /*string input = Console.ReadLine();
            try
            {
                int inputAsInt = Convert.ToInt32(input);
                um.AllStudentFromUPM(inputAsInt);

            } catch (Exception ex)
            {
                Console.WriteLine("Wrong input!!");
            }*/


            //Simple way to sort int

            /*int[] someInt = { 100, 7, 12, 50, 43 };
            IEnumerable<int> sorttedInt = from i in someInt orderby i select i;
            IEnumerable<int> reversedInt = sorttedInt.Reverse();

            foreach(int i in reversedInt)
            {
                Console.WriteLine(i);
            }

            //OR this way

            IEnumerable<int> reversedSoretedInts = from i in sorttedInt orderby i descending select i;
            foreach (int i in reversedSoretedInts)
            {
                Console.WriteLine(i);
            }*/



            Console.ReadKey();
        }



        //Linq University Manager Part 1
        class University
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public void Print()
            {
                Console.WriteLine("University {0} with id {1}", Name, Id);
            }
        }

        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }

            // Foreign Key
            public int UniversityId { get; set; }

            public void Print()
            {
                Console.WriteLine("Student {0} with id {1}, and the Gender is {2}, and the Age is " +
                    "{3}, from University with Id of {4}"
                    , Name, Id, Gender, Age, UniversityId);
            }
        }

        //Now in order to use Linq query with University we should use UniversityManager

        class UniversityManager
        {
            public List<University> universities;
            public List<Student> students;

            public UniversityManager()
            {
                //Initit
                universities = new List<University>();
                students = new List<Student>();


                //Let's Add some universities
                universities.Add(new University { Id = 1, Name = "APU" });
                universities.Add(new University { Id = 2, Name = "UPM" });

                students.Add(new Student { Id = 1, Name = "Osama", Gender = "Male", Age = 26, UniversityId = 1 });
                students.Add(new Student { Id = 2, Name = "Khaled", Gender = "Male", Age = 24, UniversityId = 2 });
                students.Add(new Student { Id = 3, Name = "Assma", Gender = "Female", Age = 34, UniversityId = 1 });
                students.Add(new Student { Id = 4, Name = "Abeer", Gender = "Female", Age = 41, UniversityId = 2 });
                students.Add(new Student { Id = 5, Name = "Omar", Gender = "Male", Age = 22, UniversityId = 1 });

            }

            //here we Linq to attach Male Gender only
            public void MaleStudent()
            {
                IEnumerable<Student> maleStudents = from student in students where student.Gender == "Male" select student;
                Console.WriteLine("Male - Students: \n");

                foreach(Student student in maleStudents)
                {
                    student.Print();
                }
            }

            //The same here for the Femal Gender
            public void FmaleStudent()
            {
                IEnumerable<Student> femaleStudents = from student in students where student.Gender == "Female" select student;
                Console.WriteLine("\nFemale - Students: \n");

                foreach (Student student in femaleStudents)
                {
                    student.Print();
                }
            }

            //now we use sorting
            public void SortStudentByAge()
            {
                //var here is a generaic type and you can't change the value of it

                var sortedStudent = from student in students orderby student.Age select student;
                Console.WriteLine("\nStudent sorted by Age: \n");
                foreach(Student student in sortedStudent)
                {
                    student.Print();
                }
            }
            public void AllStudentFromAPU()
            {
                IEnumerable<Student> allStudentOfAPU = from student in students
                                                       join university in universities on student.UniversityId
                                                       equals university.Id
                                                       where university.Name == "APU"
                                                       select student;

                Console.WriteLine("\nStudents from APU: \n");

                foreach(Student student in allStudentOfAPU)
                {
                    student.Print();
                }
            }

            public void AllStudentFromUPM(int Id)
            {
                IEnumerable<Student> allStudentOfUPM = from student in students
                                                       join university in universities on student.UniversityId
                                                       equals university.Id
                                                       where university.Name == "UPM"
                                                       select student;

                Console.WriteLine("\nStudents from UPM university {0}: \n", Id);

                foreach (Student student in allStudentOfUPM)
                {
                    student.Print();
                }
            }


            // Creating collections based on other collections
            public void StudentAndUniversityNameCollection()
            {
                var newCoolection = from student in students
                                    join uiversity in universities on student.UniversityId equals uiversity.Id
                                    orderby student.Name
                                    //here is a new collections
                                    select new { StudentName = student.Name, UniversityName = uiversity.Name };

                Console.WriteLine("\nNew Collection: \n");

                foreach(var col in newCoolection)
                {
                    Console.WriteLine("Student {0} from University {1}", col.StudentName, col.UniversityName);
                }
            }

        }








        //method of Ex2

        /*static void OddNumbers(int[] numbers)
        {
            Console.WriteLine("Odd Numbers: ");
            //This is the return type of the query,
            //which means that oddNumbers is a sequence
            //(an enumerable collection) of integers.

            IEnumerable<int> oddNumbers = from number in numbers where number % 2 != 0 select number;

            Console.WriteLine(oddNumbers);

            foreach(int i in oddNumbers)
            {
                Console.WriteLine(i);
            }
        }*/
    }
}
