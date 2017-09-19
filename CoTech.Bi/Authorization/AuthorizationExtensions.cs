using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoTech.Bi.Authorization
{
    public static class AuthorizationExtensions {
        public static long? UserId(this HttpContext context){
            var userClaim = context.User.FindFirstValue("sub");
            if(userClaim != null) return Int64.Parse(userClaim);
            string authHeader = context.Request.Headers["Authorization"];
            if(authHeader == null || !authHeader.StartsWith("Bearer ")){
                return null;
            }
            var token = authHeader.Substring(7);
            var tokenHandler = new JwtSecurityTokenHandler();
            if(!tokenHandler.CanReadToken(token)){
                return null;
            }
            try {
                var readToken = tokenHandler.ReadJwtToken(token);
                var claimsIdentity = new ClaimsIdentity(readToken.Claims);
                context.User.AddIdentity(claimsIdentity);
                return Int64.Parse(readToken.Subject);
            } catch(Exception){
                return null;
            }
        }

    }
}