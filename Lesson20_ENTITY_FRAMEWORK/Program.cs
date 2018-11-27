using Domain.AppContext;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Program
    {
        static void Main(string[] args)
        {

            //Unit.TeachersRepository.AddItem(
            //    new Teacher {
            //        FirstName = "Axel",
            //        LastName = "Primeiro",
            //        MiddleName = "Ashotovich",
            //        Department = Unit.DepartmentsRepository.AllItems.FirstOrDefault(X => X.Name == "Testing")
            //    });

            //foreach (var t in Unit.TeachersRepository.AllItems.ToList())
            //{
            //    Console.WriteLine($"{t.FirstName} {t.MiddleName} {t.LastName} {t.Department.Name}");
            //}
            //Console.ReadKey();
            Console.WriteLine("Start...");
            //int Id = 1024;
            //string Name = "Chemistry";
            //Subject s = new Subject { Name = Name };
            //Unit.SubjectsRepository.AddItem(s);
            //var it = Unit.SubjectsRepository.AllItems.FirstOrDefault(x => x.Name == "Chemistry").Id;
            //Unit.SubjectsRepository.DeleteItem(it);

            foreach (var sub in Unit.SpecialitiesRepository.AllItems)
            {
                Console.WriteLine($"{sub.Id}  {sub.Name}");
            }
            /*Department d = new Department { Name = "System Analysis" };
            Unit.DepartmentsRepository.AddItem(d);*/
            //var it = Unit.DepartmentsRepository.AllItems.FirstOrDefault(x => x.Name == "Chemistry").Id;
            //Unit.SubjectsRepository.DeleteItem(it);
            /*var it = Unit.SubjectsRepository.AllItems.FirstOrDefault(x => x.Name == "Philosophy").Id;
            Unit.SubjectsRepository.DeleteItem(it);*/
            /*Subject[] s = new Subject[]{
                new Subject { Name = "Data Analysis" },
                new Subject { Name = "Philosophy" }
                };

            Unit.SubjectsRepository.AddItems(s);*/

            Console.WriteLine("new-----");
            foreach (var sub in Unit.DepartmentsRepository.AllItems)
            {
                Console.WriteLine($"{sub.Id}  {sub.Name}");
            }
        }
    }
}
