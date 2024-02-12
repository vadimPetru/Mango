using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Mango.Services.ProductAPI.Extensions
{
    public static class AddJwtAuthenticationExtension
    {
        public static WebApplicationBuilder AddJwtAuthentication(this WebApplicationBuilder builder)
        {
            var secret = builder.Configuration.GetValue<string>("ApiSettings:Secret");
            var issuer = builder.Configuration.GetValue<string>("ApiSettings:Issuer");
            var Audience = builder.Configuration.GetValue<string>("ApiSettings:Audience");
            var key = Encoding.ASCII.GetBytes(secret);


            builder.Services.AddAuthentication(schema =>
            {
                schema.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                schema.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = Audience,

                };
            });

            return builder;
        }
    }
}
