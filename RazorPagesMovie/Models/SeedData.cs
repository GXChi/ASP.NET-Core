using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()))
            {
                if (context.Movie.Any())
                {
                    return;
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "你好！李焕英！",
                        ReleaseDate = DateTime.Parse("2021-1-1"),
                        Genre = "喜剧",
                        Price = 7.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "刺杀小说家",
                        ReleaseDate = DateTime.Parse("2021-2-11"),
                        Genre = "喜剧",
                        Price = 7.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "道门空间",
                        ReleaseDate = DateTime.Parse("1954-1-1"),
                        Genre = "喜剧",
                        Price = 7.99M,
                        Rating = "B"
                    },
                    new Movie
                    {
                        Title = "西游记",
                        ReleaseDate = DateTime.Parse("1980-1-1"),
                        Genre = "喜剧",
                        Price = 7.99M,
                        Rating = "A"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
