namespace RaceDay.API.Models;

public class RacePackTemplate {
  public int Id {get;set;}
  public int EventId {get;set;}
  public string ItemName {get;set;} = "";
  public int Quantity {get;set;}
}