using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ContextSeed
    {
        public static async Task SeedAsync(LibraryContext context, ILoggerFactory loggerFactory)
        {
            try // En try för varje tabell/entity som ska seedas
            {
                if (!context.Authors.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/authors.json");

                    var authors = JsonSerializer.Deserialize<List<Author>>(typesData);

                    foreach (var item in authors)
                    {
                        context.Authors.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if (!context.Books.Any()) // Titta om det finns någon data
                {
                    var booksData = File.ReadAllText("../Infrastructure/Data/SeedData/books.json"); // Rätt sökväg här!

                    var books = JsonSerializer.Deserialize<List<Book>>(booksData);

                    foreach (var item in books)
                    {
                        context.Books.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
