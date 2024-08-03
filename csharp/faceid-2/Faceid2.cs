using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);

    public override bool Equals(object obj) =>
        obj is FacialFeatures other && EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);

    public override bool Equals(object obj) =>
        obj is Identity other && Email == other.Email && Equals(FacialFeatures, other.FacialFeatures);
}

public class Authenticator
{
    private readonly HashSet<Identity> _registeredIdentities = [];

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => Equals(faceA, faceB);

    public bool IsAdmin(Identity identity) =>
        Equals(identity, new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m)));

    public bool Register(Identity identity) => _registeredIdentities.Add(identity);

    public bool IsRegistered(Identity identity) => _registeredIdentities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => ReferenceEquals(identityA, identityB);
}
