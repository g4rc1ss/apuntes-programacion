using static Totp.Libs.Base32;
using static Totp.Libs.Hotp;

namespace Totp;

public class HotpTest
{
    private static string _claveSecreta = "";
    private static string _claveSecreta2 = "";
    private const long CONTADOR = 12345678;

    public HotpTest()
    {
        _claveSecreta = Encode("12345");
        _claveSecreta2 = Encode("12346");
    }

    [Fact]
    public void TestGeneraOk()
    {
        string? hotpCode = GeneraHotp(CONTADOR, _claveSecreta);
        Assert.Equal("147108", hotpCode);
    }

    [Fact]
    public void TestGeneraSize8Ok()
    {
        string? hotpCode = GeneraHotp(CONTADOR, _claveSecreta, otpSize: 8);
        Assert.Equal("17147108", hotpCode);
    }

    [Fact]
    public void TestValidaOk()
    {
        string? hotpCode = GeneraHotp(CONTADOR, _claveSecreta);
        Assert.True(ValidaHotp(CONTADOR, hotpCode, _claveSecreta));
    }

    [Fact]
    public void TestErrorCodigoIncorrecto()
    {
        string? hotpCode = GeneraHotp(CONTADOR, _claveSecreta);
        Assert.False(ValidaHotp(CONTADOR, "123456", _claveSecreta));
    }

    [Fact]
    public void TestErrorOtraClave()
    {
        string? hotpCode = GeneraHotp(CONTADOR, _claveSecreta);
        Assert.False(ValidaHotp(CONTADOR, hotpCode, _claveSecreta2));
    }
}
