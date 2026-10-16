namespace RaceDay.API.Models;

public class Event {
  public int Id {get;set;}
  public string Name {get;set;} = "";
  public string Location {get;set;} = "";
  public DateTime Date {get;set;}
  public int CreatedByUserId {get;set;}
}