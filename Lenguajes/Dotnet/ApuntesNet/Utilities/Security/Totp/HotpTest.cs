using static Totp.Libs.Base32;
using static Totp.Libs.Hotp;

namespace Totp;

public class HotpTest
{
    private static string claveSecreta = "";
    private static string claveSecreta2 = "";
    private const long CONTADOR = 12345678;

    public HotpTest()
    {
        claveSecreta = Encode("12345");
        claveSecreta2 = Encode("12346");
    }

    [Fact]
    public void TestGeneraOK()
    {
        string? hotpCode = GeneraHotp(CONTADOR, claveSecreta);
        Assert.Equal("147108", hotpCode);
    }

    [Fact]
    public void TestGeneraSize8OK()
    {
        string? hotpCode = GeneraHotp(CONTADOR, claveSecreta, otpSize: 8);
        Assert.Equal("17147108", hotpCode);
    }

    [Fact]
    public void TestValidaOK()
    {
        string? hotpCode = GeneraHotp(CONTADOR, claveSecreta);
        Assert.True(ValidaHotp(CONTADOR, hotpCode, claveSecreta));
    }

    [Fact]
    public void TestErrorCodigoIncorrecto()
    {
        string? hotpCode = GeneraHotp(CONTADOR, claveSecreta);
        Assert.False(ValidaHotp(CONTADOR, "123456", claveSecreta));
    }

    [Fact]
    public void TestErrorOtraClave()
    {
        string? hotpCode = GeneraHotp(CONTADOR, claveSecreta);
        Assert.False(ValidaHotp(CONTADOR, hotpCode, claveSecreta2));
    }
}
