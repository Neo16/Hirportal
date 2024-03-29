﻿using Hirportal.Model;
using Hirportal.Model.MainPage;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hirportal.Dal
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleTag> ArticleTags { get; set; }

        public DbSet<Column> Columns { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<MainPageBlock> MainPageBlocks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ArticleTagsConfiguration());
        }
    }
}
