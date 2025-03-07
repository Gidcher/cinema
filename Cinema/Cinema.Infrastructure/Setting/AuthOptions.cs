namespace Cinema.Infrastructure.Setting;

public class AuthOptions:IAuthOptions
{
    public string Issuer { get; private init; }
    public string Audience { get; private init; }
    public string Key { get; private init; }
    public bool ValidateIssuer { get; private init; }
    public bool ValidateAudience { get; private init; }
    public bool ValidateLifetime { get; private init; }
    public bool ValidateIssuerSigningKey { get; private init; }
    public bool RequireExpirationTime { get; private init; }
    
}