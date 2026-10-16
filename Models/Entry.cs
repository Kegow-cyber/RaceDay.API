namespace RaceDay.API.Models;

public class Entry {
  public int Id {get;set;}
  public int UserId {get;set;}
  public int CategoryId {get;set;}
  public int EventId {get;set;}
  public DateTime EntryDate {get;set;} = DateTime.UtcNow;
  public bool IsPaid {get;set;}
}