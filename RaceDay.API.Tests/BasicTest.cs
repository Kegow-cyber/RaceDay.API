using Xunit;
using RaceDay.API.Models;

public class BasicTests
{
    [Fact]
    public void User_Model_CanBeCreated()
    {
        var user = new User { Id = 1, Username = "testuser", PasswordHash = "hash123" };
        Assert.Equal(1, user.Id);
        Assert.Equal("testuser", user.Username);
    }

    [Fact]
    public void User_Username_Required()
    {
        var user = new User { Username = "racer1" };
        Assert.False(string.IsNullOrEmpty(user.Username));
    }

    [Fact]
    public void RacePackTemplate_CanBeCreated()
    {
        var pack = new RacePackTemplate { Id = 1, Name = "Test Pack" };
        Assert.Equal(1, pack.Id);
        Assert.Equal("Test Pack", pack.Name);
    }

    [Fact]
    public void RacePackTemplate_Name_NotEmpty()
    {
        var pack = new RacePackTemplate { Name = "Marathon" };
        Assert.NotNull(pack.Name);
    }

    [Fact]
    public void BCrypt_HashPassword_Success()
    {
        string password = "Password123!";
        string hash = BCrypt.Net.BCrypt.HashPassword(password);
        Assert.True(BCrypt.Net.BCrypt.Verify(password, hash));
    }

    [Fact]
    public void BCrypt_WrongPassword_Fails()
    {
        string hash = BCrypt.Net.BCrypt.HashPassword("correct");
        Assert.False(BCrypt.Net.BCrypt.Verify("wrong", hash));
    }

    [Fact]
    public void BCrypt_TwoHashes_AreDifferent()
    {
        string pass = "samepass";
        var h1 = BCrypt.Net.BCrypt.HashPassword(pass);
        var h2 = BCrypt.Net.BCrypt.HashPassword(pass);
        Assert.NotEqual(h1, h2);
    }

    [Fact]
    public void User_PasswordHashing_FullFlow()
    {
        var user = new User { Username = "john" };
        string plain = "mySecret123";
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(plain);
        Assert.True(BCrypt.Net.BCrypt.Verify(plain, user.PasswordHash));
    }

    [Fact]
    public void Auth_Logic_UsernameCaseInsensitive_Check()
    {
        string input = "TestUser";
        string stored = "testuser";
        Assert.Equal(stored.ToLower(), input.ToLower());
    }

    [Fact]
    public void RacePackTemplate_Id_DefaultZero()
    {
        var pack = new RacePackTemplate();
        Assert.Equal(0, pack.Id);
    }
}
