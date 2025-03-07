using System.Text;
using Cinema.Infrastructure.Setting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthorizationExtension(this IServiceCollection service, IConfiguration config)
    {
        ArgumentNullException.ThrowIfNull(config);
        var authOptions = config
            .GetSection(nameof(AuthOptions))
            .Get<AuthOptions>(options => options.BindNonPublicProperties = true);
        service.AddSingleton(authOptions);
        service.AddSingleton<ITokenProvider>(t => new TokenProvider(authOptions));
        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = authOptions.ValidateIssuer,
                    ValidIssuer = authOptions.Issuer,
                    ValidateAudience = authOptions.ValidateAudience,
                    ValidAudience = authOptions.Audience,
                    ValidateLifetime = authOptions.ValidateLifetime,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Key)),
                    ValidateIssuerSigningKey = authOptions.ValidateIssuerSigningKey,
                    RequireExpirationTime = authOptions.RequireExpirationTime
                };
            });
        service.AddAuthorization(); 
        return service;
    }
}