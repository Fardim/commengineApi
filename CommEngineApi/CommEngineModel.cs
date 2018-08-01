using CommEngineApi.Models;

namespace CommEngineApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CommEngineModel : DbContext
    {
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public CommEngineModel()
            : base("name=CommEngineModel")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasRequired(d=> d.Categories).WithMany().HasForeignKey(d=> d.CategoryId).WillCascadeOnDelete(false);
        }
    }
}
