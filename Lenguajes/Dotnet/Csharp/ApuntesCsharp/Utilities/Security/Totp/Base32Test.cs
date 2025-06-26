using static Totp.Libs.Base32;

namespace Totp;

public class Base32Test
{
    #region RFC 4648 Test Vectors (https: //tools.ietf.org/html/rfc4648#section-10)

    [Fact]
    public void Base32Test1Encode()
    {
        Assert.Equal("", Encode(""));
    }

    [Fact]
    public void Base32Test2Encode()
    {
        Assert.Equal("MY======", Encode("f"));
    }

    [Fact]
    public void Base32Test3Encode()
    {
        Assert.Equal("MZXQ====", Encode("fo"));
    }

    [Fact]
    public void Base32Test4Encode()
    {
        Assert.Equal("MZXW6===", Encode("foo"));
    }

    [Fact]
    public void Base32Test5Encode()
    {
        Assert.Equal("MZXW6YQ=", Encode("foob"));
    }

    [Fact]
    public void Base32Test6Encode()
    {
        Assert.Equal("MZXW6YTB", Encode("fooba"));
    }

    [Fact]
    public void Base32Test7Encode()
    {
        Assert.Equal("MZXW6YTBOI======", Encode("foobar"));
    }

    [Fact]
    public void Base32Test1Decode()
    {
        Assert.Equal("", Decode(""));
    }

    [Fact]
    public void Base32Test2Decode()
    {
        Assert.Equal("f", Decode("MY======"));
    }

    [Fact]
    public void Base32Test3Decode()
    {
        Assert.Equal("fo", Decode("MZXQ===="));
    }

    [Fact]
    public void Base32Test4Decode()
    {
        Assert.Equal("foo", Decode("MZXW6==="));
    }

    [Fact]
    public void Base32Test5Decode()
    {
        Assert.Equal("foob", Decode("MZXW6YQ="));
    }

    [Fact]
    public void Base32Test6Decode()
    {
        Assert.Equal("fooba", Decode("MZXW6YTB"));
    }

    [Fact]
    public void Base32Test7Decode()
    {
        Assert.Equal("foobar", Decode("MZXW6YTBOI======"));
    }

    #endregion

    #region Bad input tests

    [Fact]
    public void Base32TestSingleChar()
    {
        // assert
        Assert.Throws<FormatException>(() => Decode("M"));
    }

    [Fact]
    public void Base32TestIncompletePadding()
    {
        // assert
        Assert.Throws<FormatException>(() => Decode("MZXW6YTBOI====="));
    }

    [Fact]
    public void Base32TestPlainPadding()
    {
        // assert
        Assert.Throws<FormatException>(() => Decode("========"));
    }

    [Fact]
    public void Base32TestPaddingInsideText()
    {
        // assert
        Assert.Throws<FormatException>(() => Decode("MZX=6YQ="));
    }

    [Fact]
    public void Base32TestBadCharInsideAlphabetRange()
    {
        // assert
        Assert.Throws<FormatException>(() => Decode("MZX96YQ="));
    }

    [Fact]
    public void Base32TestBadCharOutsideAlphabetRangeLeft()
    {
        Assert.Throws<FormatException>(() => Decode("MZX96YQ="));
    }

    [Fact]
    public void Base32TestBadCharOutsideAlphabetRangeRight()
    {
        Assert.Throws<FormatException>(() => Decode("MZX~6YQ="));
    }

    #endregion

    #region Complex tests

    private const string COMPLEX1_TEXT =
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, "
        + "sed eiusmod tempor incidunt ut labore et dolore magna aliqua. "
        + "Ut enim ad minim veniam, quis nostrud exercitation...";

    private const string COMPLEX1_BASE32 =
        "JRXXEZLNEBUXA43VNUQGI33MN5ZCA43JOQQGC3LFOQWCAY3PNZZWKY3UMV2H"
        + "K4RAMFSGS4DJONRWS3THEBSWY2LUFQQHGZLEEBSWS5LTNVXWIIDUMVWXA33S"
        + "EBUW4Y3JMR2W45BAOV2CA3DBMJXXEZJAMV2CAZDPNRXXEZJANVQWO3TBEBQW"
        + "Y2LROVQS4ICVOQQGK3TJNUQGCZBANVUW42LNEB3GK3TJMFWSYIDROVUXGIDO"
        + "N5ZXI4TVMQQGK6DFOJRWS5DBORUW63ROFYXA====";

    [Fact]
    public void Base32TestComplex1Encode()
    {
        Assert.Equal(COMPLEX1_BASE32, Encode(COMPLEX1_TEXT));
    }

    [Fact]
    public void Base32TestComplex1Decode()
    {
        Assert.Equal(COMPLEX1_TEXT, Decode(COMPLEX1_BASE32));
    }

    [Fact]
    public void Base32TestComplex1RandomEncodeDecode()
    {
        string? input = Path.GetRandomFileName();
        Assert.Equal(input, Decode(Encode(input)));
    }

    #endregion
}
