using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Allin.Common.Web
{
    public struct ClaimTypes
    {
        public const string NameIdentifier = "nameId";
        public const string Email = "email";
        public const string Sid = "sid";
        public const string FirstName = "firstName";
        public const string SecondName = "secondName";
        /// <summary>
        /// JSON Token ID
        /// </summary>
        public const string Jti = "jti";
    }

    public interface IUserAccessor
    {
        public int GetId();

        public string? GetIp();
        public string? GetUsername();
        public string? GetUserFullName();
        public T? GetClaim<T>(string claimName);
    }

    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetId()
        {
            return int.Parse(_httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value ?? "0");
        }

        //TODO by Muhammad: Candidate for deletion
        // public string? GetRefreshToken()
        // {
        //     return _httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == "RefreshToken")?.Value;
        // }

        public T? GetClaim<T>(string claimName)
        {
            return (T?)Convert.ChangeType(_httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == claimName)?.Value ?? null, typeof(T));
        }

        public string? GetIp()
        {
            return _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString();
        }

        public string? GetUsername()
        {
            return _httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? null;
        }

        public string? GetUserFullName()
        {
            var firstName = _httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.FirstName)?.Value ?? null;
            var secondName = _httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.SecondName)?.Value ?? null;
            return $"{firstName} {secondName}".Trim();
        }

        public bool IsExpiredToken()
        {
            var expClaim = _httpContextAccessor?.HttpContext?.User?.Claims
                                .FirstOrDefault(x => x.Type == "exp");
            if (expClaim == default)
            {
                throw new Exception("No user claim provided for 'exp'");
            }

            var b = (DateTimeOffset
                .FromUnixTimeSeconds(long.Parse(expClaim.Value)));

            var c = DateTimeOffset.Now;


            var d = b - c < TimeSpan.FromSeconds(10);


            return d;
        }
    }

}
