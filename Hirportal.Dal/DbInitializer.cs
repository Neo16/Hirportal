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
                    CoverImageUrl = r.Next(0, 5) < 4 ? "http://placehold.it/800x" + r.Next(500, 741).ToString() : null
                });

            var articleList = articles.ToList();

            foreach (Article a in articleList)
            {
                a.ThumbnailContent = a.CoverImageUrl == null ? LoremHelper.Text.Substring(0, 300) : LoremHelper.Text.Substring(0, 150);

                if (a.CoverImageUrl == null)
                {
                    a.Title = a.Title + " " + a.Title;
                }
            }

            context.Tags.AddRange(tags);
            context.Columns.AddRange(columns);
            context.Articles.AddRange(articleList);

            context.SaveChanges();

            return context;
        }

        public static ApplicationDbContext CreateMainPageBlocks(this ApplicationDbContext context, int numberOfBlocks)
        {
            var articles = context.Articles
                .ToList();
            var articleMaxIndex = articles.Count() - 1;

            var r = new Random();

            //Add blocks 
            var blocks = Enumerable.Range(1, numberOfBlocks)
                .Select(e => new MainPageBlock()
                {
                    Name = "Example block " + e.ToString(),
                    MainPageCells = new List<MainPageCell>()
                    {
                        new MainPageCell(){ DisplayId = 1,  Article =  articles.ElementAt(r.Next(0,articleMaxIndex)), CellSize=CellSize.NORMAL},
                        new MainPageCell(){ DisplayId = 2,  Article =  articles.ElementAt(r.Next(0,articleMaxIndex)), CellSize=CellSize.NORMAL},
                        new MainPageCell(){ DisplayId = 3,  Article =  articles.ElementAt(r.Next(0,articleMaxIndex)), CellSize=CellSize.NORMAL},
                        new MainPageCell(){ DisplayId = 4,  Article =  articles.ElementAt(r.Next(0,articleMaxIndex)), CellSize=CellSize.NORMAL}
                    },
                    IsLeadBlock = false
                })
                .ToList();

            //Set leadblock 
            var blockList = blocks.ToList();
            blockList[0].IsLeadBlock = true;
            blockList[0].MainPageCells[0].CellSize = CellSize.LEAD; //vezércikk (8 széles)
            blockList[0].MainPageCells[1].CellSize = CellSize.WIDE; // mellette egy 4 széles cikk 
            blockList[0].MainPageCells.AddRange(
                new List<MainPageCell>()
                {
                    new MainPageCell(){ DisplayId = 1,  Article =  articles.ElementAt(r.Next(0,articleMaxIndex))},
                    new MainPageCell(){ DisplayId = 2,  Article =  articles.ElementAt(r.Next(0,articleMaxIndex))},
                }
            );

            //Set some cells to bigger sizes 
            blockList[1].MainPageCells.RemoveAt(0);
            blockList[1].MainPageCells.ForEach(e => e.CellSize = CellSize.WIDE);

            blockList[2].MainPageCells.RemoveAt(0);
            blockList[2].MainPageCells.RemoveAt(1);
            blockList[2].MainPageCells.ForEach(e => e.CellSize = CellSize.LARGE);

            context.MainPageBlocks.AddRange(blocks);
            context.SaveChanges();

            return context;
        }
    }
}
