using System;
using Domain.AppContext;
using Domain.Entities;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.AppContext
{
    //DropCreateDatabaseAlways<MyAppDbContext>
    //DropCreateDatabaseIfModelChanges<MyAppDbContext>
    //CreateDatabaseIfNotExists<MyAppDbContext>

    public class MyAppDbContextInitializer : CreateDatabaseIfNotExists<MyAppDbContext>
    {
        protected override void Seed(MyAppDbContext context)
        {
            // initialize context with prepared data
            base.Seed(context);
            
            #region Seed
            List<Department> departments = new List<Department>
            {
                new Department { Name = "Software Testing " },
                new Department { Name = "Programming and System Analysis" }
            };
            departments.ForEach(d => context.Departments.Add(d));
            context.SaveChanges();

            List<Subject> subjects = new List<Subject>
            {
                new Subject { Name = "Calculus"},
                new Subject { Name = "Math Analysis" },
                new Subject { Name = "Operation Systems" },
                new Subject { Name = "Databases Theory" },
                new Subject { Name = "Application Testing" }
            };
            subjects.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();

            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher {
                    FirstName = "Max",
                    LastName = "Frei",
                    MiddleName = "Unknown",
                    Department = context.Departments.FirstOrDefault(d=>d.Id == 1)
                },
                new Teacher {
                    FirstName = "Tyler",
                    LastName = "Durden",
                    MiddleName = "Unknown",
                    Department =  context.Departments.FirstOrDefault(d => d.Id == 1)
                },
                new Teacher {
                    FirstName = "Dean",
                    LastName = "Moriarty",
                    MiddleName = "Unknown",
                    Department =  context.Departments.FirstOrDefault(d => d.Id == 2),
                },
                new Teacher {
                    FirstName = "Sal",
                    LastName = "Paradise",
                    MiddleName = "Unknown",
                    Department =  context.Departments.FirstOrDefault(d => d.Id == 2),
                }
            };
            teachers.ForEach(t => context.Teachers.Add(t));
            context.SaveChanges();

            List<TeachSubj> teachSubjs = new List<TeachSubj>
            {
                new TeachSubj { Teacher = context.Teachers.FirstOrDefault(t=>t.Id == 1),
                    Subject = context.Subjects.FirstOrDefault(s=>s.Id == 1)},
                new TeachSubj { Teacher = context.Teachers.FirstOrDefault(t=>t.Id == 1),
                    Subject = context.Subjects.FirstOrDefault(s=>s.Id == 2)},
                new TeachSubj { Teacher = context.Teachers.FirstOrDefault(t=>t.Id == 2),
                    Subject = context.Subjects.FirstOrDefault(s=>s.Id == 3)},
                new TeachSubj { Teacher = context.Teachers.FirstOrDefault(t=>t.Id == 2),
                    Subject = context.Subjects.FirstOrDefault(s=>s.Id == 4)},
                new TeachSubj { Teacher = context.Teachers.FirstOrDefault(t=>t.Id == 3),
                    Subject = context.Subjects.FirstOrDefault(s=>s.Id == 5)},
                new TeachSubj { Teacher = context.Teachers.FirstOrDefault(t=>t.Id == 4),
                    Subject = context.Subjects.FirstOrDefault(s=>s.Id == 2)},
                new TeachSubj { Teacher = context.Teachers.FirstOrDefault(t=>t.Id == 4),
                    Subject = context.Subjects.FirstOrDefault(s=>s.Id == 4)},
            };
            teachSubjs.ForEach(s => context.TeachSubjs.Add(s));
            context.SaveChanges();

            List<Speciality> specialities = new List<Speciality>
            {
                new Speciality { Name = "Testing" },
                new Speciality { Name = "Programming" }
            };
            specialities.ForEach(s => context.Specialities.Add(s));
            context.SaveChanges();

            List<Group> groups = new List<Group>
            {
                new Group { Name = "T-18-1", Speciality = context.Specialities.FirstOrDefault(s=>s.Id == 1) },
                new Group { Name = "T-18-2", Speciality = context.Specialities.FirstOrDefault(s=>s.Id == 1) },
                new Group { Name = "P-17-1", Speciality = context.Specialities.FirstOrDefault(s=>s.Id == 2) },
                new Group { Name = "P-18-1", Speciality = context.Specialities.FirstOrDefault(s=>s.Id == 2) },
                new Group { Name = "P-18-2", Speciality = context.Specialities.FirstOrDefault(s=>s.Id == 2) },
            };
            groups.ForEach(s => context.Groups.Add(s));
            context.SaveChanges();

            List<Student> students = new List<Student>
            {
                new Student { FirstName = "Edward", MiddleName = "John", LastName = "Hedge",
                Address = "Toronto", Birthday = new DateTime(1993,10,10), Email = "ed_hedgehog@gmail.com",
                LogbookNumber = 00012, Group = context.Groups.FirstOrDefault(g=>g.Id == 1)},
                new Student { FirstName = "Margaret", MiddleName = "Ihorovna", LastName = "Starchenko",
                Address = "Dnipro", Birthday = new DateTime(1993,3,7), Email = "rita_starchenko@gmail.com",
                LogbookNumber = 00101, Group = context.Groups.FirstOrDefault(g=>g.Id == 1)},
                new Student { FirstName = "Peter", MiddleName = "Tomas", LastName = "Black",
                Address = "Ontario", Birthday = new DateTime(1992,1,30), Email = "ptblack@gmail.com",
                LogbookNumber = 00009, Group = context.Groups.FirstOrDefault(g=>g.Id == 2)},
                new Student { FirstName = "Tomas", MiddleName = "Unknown", LastName = "Spolding",
                Address = "Greentown", Birthday = new DateTime(1994,2,1), Email = "tomspolding12@gmail.com",
                LogbookNumber = 00132, Group = context.Groups.FirstOrDefault(g=>g.Id == 2)},
                new Student { FirstName = "Douglas", MiddleName = "Unknown", LastName = "Spolding",
                Address = "Greentown", Birthday = new DateTime(1991,4,23), Email = "great_doug4@gmail.com",
                LogbookNumber = 00002, Group = context.Groups.FirstOrDefault(g=>g.Id == 3)},
                new Student { FirstName = "Leo", MiddleName = "Unknown", LastName = "Aufmann",
                Address = "Greentown", Birthday = new DateTime(1971,9,2), Email = "happy_leo@gmail.com",
                LogbookNumber = 00012, Group = context.Groups.FirstOrDefault(g=>g.Id == 4)},
                new Student { FirstName = "Maxine", MiddleName = "Unknown", LastName = "Caulfield",
                Address = "Arcadia Bay", Birthday = new DateTime(1997,9,4), Email = "max_caulfield7@gmail.com",
                LogbookNumber = 00293, Group = context.Groups.FirstOrDefault(g=>g.Id == 5)},
                new Student { FirstName = "Victoria", MiddleName = "Unknown", LastName = "Chase",
                Address = "Arcadia Bay", Birthday = new DateTime(1997,1,15), Email = "vic_chase@gmail.com",
                LogbookNumber = 00220, Group = context.Groups.FirstOrDefault(g=>g.Id == 5)}
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            List<Phone> phones = new List<Phone>
            {
                new Phone{StudentsPhone = "0998894464", Student = context.Students.FirstOrDefault(s=>s.Id == 1)},
                new Phone{StudentsPhone = "0998894465", Student = context.Students.FirstOrDefault(s=>s.Id == 2)},
                new Phone{StudentsPhone = "0998894466", Student = context.Students.FirstOrDefault(s=>s.Id == 3)},
                new Phone{StudentsPhone = "0998894467", Student = context.Students.FirstOrDefault(s=>s.Id == 4)},
                new Phone{StudentsPhone = "0998893407", Student = context.Students.FirstOrDefault(s=>s.Id == 5)},
                new Phone{StudentsPhone = "0992891462", Student = context.Students.FirstOrDefault(s=>s.Id == 6)},
                new Phone{StudentsPhone = "0991094461", Student = context.Students.FirstOrDefault(s=>s.Id == 7)},
                new Phone{StudentsPhone = "0990894460", Student = context.Students.FirstOrDefault(s=>s.Id == 8)},
            };
            phones.ForEach(p => context.Phones.Add(p));
            context.SaveChanges();

            List<Mark> marks = new List<Mark>
            {
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 1),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 1),
                            StudentsMark = 95},
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 1),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 2),
                            StudentsMark = 87},
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 1),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 3),
                            StudentsMark = 89},
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 1),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 4),
                            StudentsMark = 75},
                //------
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 2),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 1),
                            StudentsMark = 67},
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 2),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 2),
                            StudentsMark = 71},
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 2),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 3),
                            StudentsMark = 92},
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 2),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 4),
                            StudentsMark = 77},
                //------
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 3),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 1),
                            StudentsMark = 98},
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 3),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 2),
                            StudentsMark = 88},
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 3),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 3),
                            StudentsMark = 68},
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 3),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 4),
                            StudentsMark = 73},
                //------
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 4),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 1),
                            StudentsMark = 67},
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 4),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 2),
                            StudentsMark = 68},
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 4),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 4),
                            StudentsMark = 73},
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 4),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 5),
                            StudentsMark = 99},
                //------
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 5),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 1),
                            StudentsMark = 67},
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 5),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 2),
                            StudentsMark = 68},
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 5),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 3),
                            StudentsMark = 73},
                new Mark{Student = context.Students.FirstOrDefault(s=>s.Id == 5),
                            TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 5),
                            StudentsMark = 99},

            };
            marks.ForEach(p => context.Marks.Add(p));
            context.SaveChanges();

            //----------Schedule------------------------------
            List<Audience> audiences = new List<Audience>
            {
                new Audience{ Name = "101"},
                new Audience{ Name = "102"},
                new Audience{ Name = "103"},
                new Audience{ Name = "201"},
                new Audience{ Name = "202"}
            };
            audiences.ForEach(s => context.Audiences.Add(s));
            context.SaveChanges();

            List<Lection> lections = new List<Lection>
            {
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,8,0,0),
                    Finish = new DateTime(1970,1,1,9,20,0)},
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,9,35,0),
                    Finish = new DateTime(1970,1,1,10,55,0)},
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,11,20,0),
                    Finish = new DateTime(1970,1,1,12,40,0)},
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,12,55,0),
                    Finish = new DateTime(1970,1,1,14,15,0)},
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,14,30,0),
                    Finish = new DateTime(1970,1,1,15,50,0)},
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,16,5,0),
                    Finish = new DateTime(1970,1,1,17,25,0)},
            };
            lections.ForEach(s => context.Lections.Add(s));
            context.SaveChanges();

            List<AudLect> audLects = new List<AudLect>
            {
                new AudLect{ Audience = context.Audiences.FirstOrDefault(s=>s.Id == 1),
                             Lection = context.Lections.FirstOrDefault(s=>s.Id == 1),
                             Group = context.Groups.FirstOrDefault(s=>s.Id == 1),
                             TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 1)},
                new AudLect{ Audience = context.Audiences.FirstOrDefault(s=>s.Id == 1),
                             Lection = context.Lections.FirstOrDefault(s=>s.Id == 2),
                             Group = context.Groups.FirstOrDefault(s=>s.Id == 1),
                             TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 2)},
                new AudLect{ Audience = context.Audiences.FirstOrDefault(s=>s.Id == 1),
                             Lection = context.Lections.FirstOrDefault(s=>s.Id == 3),
                             Group = context.Groups.FirstOrDefault(s=>s.Id == 2),
                             TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 3)},
                new AudLect{ Audience = context.Audiences.FirstOrDefault(s=>s.Id == 1),
                             Lection = context.Lections.FirstOrDefault(s=>s.Id == 4),
                             Group = context.Groups.FirstOrDefault(s=>s.Id == 2),
                             TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 2)},
                new AudLect{ Audience = context.Audiences.FirstOrDefault(s=>s.Id == 1),
                             Lection = context.Lections.FirstOrDefault(s=>s.Id == 5),
                             Group = context.Groups.FirstOrDefault(s=>s.Id == 3),
                             TeachSubj = context.TeachSubjs.FirstOrDefault(t=>t.Id == 2)}
            };
            audLects.ForEach(s => context.AudLects.Add(s));
            context.SaveChanges();
            #endregion

        }

    }
}
