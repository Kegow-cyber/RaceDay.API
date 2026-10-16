namespace RaceDay.API.Models;

public enum UserRole { Organiser, Participant }

public class User {
  public int Id {get;set;}
  public string FirstName {get;set;} = "";
  public string LastName {get;set;} = "";
  public string Email {get;set;} = "";
  public string PasswordHash {get;set;} = "";
  public UserRole Role {get;set;}
}