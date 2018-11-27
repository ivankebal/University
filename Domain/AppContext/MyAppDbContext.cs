using Domain.AppContext;
using Domain.Entities;
using System.Data.Entity;
using System.Linq;

namespace Domain.AppContext
{
    public class MyAppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Audience> Audiences { get; set; }
        public DbSet<Lection> Lections { get; set; }
        public DbSet<AudLect> AudLects { get; set; }
        public DbSet<TeachSubj> TeachSubjs { get; set; }
        public MyAppDbContext(string ConnStrOrDatabaseName)
            : base(ConnStrOrDatabaseName)
        {
            Database.SetInitializer(new MyAppDbContextInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AudLect>()
                .HasKey(x => new { x.AudId, x.LectId, x.GroupId });


            modelBuilder.Entity<AudLect>()
                .HasRequired(e => e.Audience)
                .WithMany(e => e.AudLects)
                .HasForeignKey(e => e.AudId);

            modelBuilder.Entity<AudLect>()
                .HasRequired(e => e.Lection)
                .WithMany(e => e.AudLects)
                .HasForeignKey(e => e.LectId);

            modelBuilder.Entity<AudLect>()
                .HasRequired(e => e.Group)
                .WithMany(e => e.AudLects)
                .HasForeignKey(e => e.GroupId);


            //--------------------------------------------
            modelBuilder.Entity<TeachSubj>()
                .HasKey(x => new { x.TeacherId, x.SubjId });

            modelBuilder.Entity<TeachSubj>()
                .HasRequired(e => e.Teacher)
                .WithMany(e => e.TeachSubj)
                .HasForeignKey(e => e.TeacherId);

            modelBuilder.Entity<TeachSubj>()
                .HasRequired(e => e.Subject)
                .WithMany(e => e.TeachSubj)
                .HasForeignKey(e => e.SubjId);


        }
    }
}