using ApiMusicDaniiiii.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiMusicDaniiiii.Data
{
    public class ApiDbContext : DbContext
    {

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Songs> Songs { get; set; }

    }
}
