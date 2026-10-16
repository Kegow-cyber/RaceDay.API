namespace RaceDay.API.Models;

public class RacePack {
  public int Id {get;set;}
  public int EntryId {get;set;}
  public string BibNumber {get;set;} = "";
  public bool IsCollected {get;set;}
  public DateTime? CollectionDate {get;set;}
}