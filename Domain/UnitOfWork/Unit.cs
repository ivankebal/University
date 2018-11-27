using Domain.Repositories;
using Domain.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class Unit
    {
        private static MyAppDbContext _context;
        static Unit()
        {
            _context = new MyAppDbContext("MyAppConnStr");
            DepartmentsRepository = new DepartmentsRepository(_context);
            TeachersRepository = new TeachersRepository(_context);
            SubjectsRepository = new SubjectsRepository(_context);
            SpecialitiesRepository = new SpecialitiesRepository(_context);
            GroupsRepository = new GroupsRepository(_context);
            PhonesRepository = new PhonesRepository(_context);
            StudentsRepository = new StudentsRepository(_context);
            AudiencesRepository = new AudiencesRepository(_context);
            AudLectRepository = new AudLectRepository(_context);
            LectionsRepository = new LectionsRepository(_context);
            MarksRepository = new MarksRepository(_context);
            TeachSubjRepository = new TeachSubjRepository(_context);
        }
        public static DepartmentsRepository DepartmentsRepository { get; set; }
        public static TeachersRepository TeachersRepository { get; set; }
        public static SubjectsRepository SubjectsRepository { get; set; }
        public static SpecialitiesRepository SpecialitiesRepository { get; set; }
        public static GroupsRepository GroupsRepository { get; set; }
        public static PhonesRepository PhonesRepository { get; set; }
        public static StudentsRepository StudentsRepository { get; set; }
        public static AudiencesRepository AudiencesRepository { get; set; }
        public static AudLectRepository AudLectRepository { get; set; }
        public static LectionsRepository LectionsRepository { get; set; }
        public static MarksRepository MarksRepository { get; set; }
        public static TeachSubjRepository TeachSubjRepository { get; set; }

    }
}
