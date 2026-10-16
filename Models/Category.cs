namespace RaceDay.API.Models;

public class Category {
  public int Id {get;set;}
  public int EventId {get;set;}
  public string Name {get;set;} = "";
  public double DistanceKm {get;set;}
  public decimal EntryFee {get;set;}
  public int MaxParticipants {get;set;}
}