using System;
using System.Data.Entity;
using System.Linq;

namespace SpendingManagement.Models.EF
{
    public class FilmDbContext : DbContext
    {
        // Your context has been configured to use a 'FilmDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SpendingManagement.Models.EF.FilmDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FilmDbContext' 
        // connection string in the application configuration file.
        public FilmDbContext()
            : base("name=FilmDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<film> Films { get; set; }
        public virtual DbSet<category> Categories { get; set; }
        public virtual DbSet<language> Languages { get; set; }
        public virtual DbSet<rating> Ratings { get; set; }
        public virtual DbSet<status> Statuses { get; set; }
        public virtual DbSet<country> Countries { get; set; } 
        public virtual DbSet<hashtag> Hashtags { get; set; }
        public virtual DbSet<hashtag_film> Hashtag_Films { get; set; }
        public virtual DbSet<image> Images { get; set; }
        public virtual DbSet<image_film> Image_Films { get; set; }
        public virtual DbSet<quality> Quanlities { get; set; }
        public virtual DbSet<slide> Slides { get; set; }
        public virtual DbSet<category_film> Category_Films { get; set; }
        public virtual DbSet<language_film> Language_Films { get; set; }
        public virtual DbSet<settingadmin> Settingadmins { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}