using Hirportal.Model;
using Hirportal.Model.MainPage;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hirportal.Dal
{
    public static class DbInitializer
    {
        public static void Seed(this ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Articles.Any())
            {
                return;   // DB has been seeded
            }
            context
                .CreateAdmins()
                .CreateArticles(100)
                .CreateMainPageBlocks(5);
        }

        public static ApplicationDbContext CreateAdmins(this ApplicationDbContext context)
        {
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            var admin = new ApplicationUser()
            {
                Email = "admin@fuz.io",
                NormalizedEmail = "ADMIN@FUZ.IO",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                SecurityStamp = "345435kl5m3k45m34k",
                PhoneNumber = "+311124211",
            };

            admin.PasswordHash = passwordHasher.HashPassword(admin, "Asdf123!");
            context.Users.Add(admin);

            context.SaveChanges();
            return context;
        }

        public static ApplicationDbContext CreateArticles(this ApplicationDbContext context, int numberOfArticles)
        {
            var tags = new List<Tag>()
            {
                new Tag() { Value = "Kosárlabda" },
                new Tag() { Value = "Mozi" },
                new Tag() { Value = "Kiss Gábor" },
            };

            var columns = new List<Column>()
            {
                new Column() { Name ="Belföld"},
                new Column() { Name ="Küldöld"},
                new Column() { Name ="Sport"},
                new Column() { Name ="Közélet"},
            };

            var r = new Random();

            var articles = Enumerable.Range(1, numberOfArticles)
                .Select(e => new Article()
                {
                    ArchiveDate = DateTime.Today.AddDays(30),
                    ArticleTags = tags.GetRange(0, r.Next(0, tags.Count - 1))
                                  .Select(t => new ArticleTag() { Tag = t }).ToList(),
                    Author = context.Users.First(),
                    Column = columns.ElementAt(r.Next(0, columns.Count - 1)),
                    HtmlContent = LoremHelper.Text,
                    PublishDate = DateTime.Now,
                    Title = "Példa Cikk " + e.ToString(),
                    ThumbnailContent = LoremHelper.Text.Substring(0, 150)
                });

            context.Tags.AddRange(tags);
            context.Columns.AddRange(columns);
            context.Articles.AddRange(articles);

            context.SaveChanges();

            return context;
        }

        public static ApplicationDbContext CreateMainPageBlocks(this ApplicationDbContext context, int numberOfBlocks)
        {
            var articles = context.Articles
                .ToList();
            var articleMaxIndex = articles.Count() - 1;

            var r = new Random();

            var blocks = Enumerable.Range(1, numberOfBlocks)
                .Select(e => new MainPageBlock()
                {
                    Name = "Example block " + e.ToString(),
                    MainPageCells = new List<MainPageCell>()
                    {
                        new MainPageCell(){ DisplayId = 1,  Article =  articles.ElementAt(r.Next(0,articleMaxIndex))},
                        new MainPageCell(){ DisplayId = 2,  Article =  articles.ElementAt(r.Next(0,articleMaxIndex))},
                        new MainPageCell(){ DisplayId = 3,  Article =  articles.ElementAt(r.Next(0,articleMaxIndex))},
                        new MainPageCell(){ DisplayId = 4,  Article =  articles.ElementAt(r.Next(0,articleMaxIndex))}
                    }
                })
                .ToList();

            context.MainPageBlocks.AddRange(blocks);
            context.SaveChanges();

            return context;
        }
    }
}
