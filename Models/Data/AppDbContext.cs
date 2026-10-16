using Microsoft.EntityFrameworkCore;
using RaceDay.API.Models;

namespace RaceDay.API.Data;

public class AppDbContext : DbContext {
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

  public DbSet<User> Users => Set<User>();
  public DbSet<Event> Events => Set<Event>();
  public DbSet<Category> Categories => Set<Category>();
  public DbSet<Entry> Entries => Set<Entry>();
  public DbSet<RacePack> RacePacks => Set<RacePack>();
  public DbSet<RacePackTemplate> RacePackTemplates => Set<RacePackTemplate>();
}