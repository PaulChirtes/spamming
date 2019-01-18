namespace PartTimeJobs.DAL.DbContext
{
    using PartTimeJobs.DAL.Models;
    using System.Data.Entity;

    public class PartTimeJobsDbContext : DbContext
    {
        // Your context has been configured to use a 'PartTimeJobsDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PartTimeJobs.DAL.DbContext.PartTimeJobsDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PartTimeJobsDbContext' 
        // connection string in the application configuration file.
        public PartTimeJobsDbContext()
            : base("name=PartTimeJobsDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasMany<Job>(user => user.JobsAssinged).WithOptional(job => job.Asignee);
            modelBuilder.Entity<User>().HasMany<Job>(user => user.JobsCreated).WithRequired(job => job.Owner);
            modelBuilder.Entity<User>().HasMany<Skill>(user => user.Skills).WithMany(skill => skill.Users);
            modelBuilder.Entity<Job>().HasMany<Skill>(job => job.RequiredSkills).WithMany(skill => skill.Jobs);
        }
    }
}