using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using WAMA.Web.Model;

namespace WAMA.Web.Controllers
{
    public abstract class WamaBaseController : Controller
    {
        private static byte[] _EncryptionSalt;

        static WamaBaseController()
        {
            // generate a 128-bit salt using a secure PRNG
            _EncryptionSalt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(_EncryptionSalt);
            }
        }

        protected void SetActiveConsoleTool(string tool)
        {
            ViewData[Constants.ADMIN_CONSOLE_ACTIVE_TOOL] = tool;
        }

        public void SetSuccessMessages(params string[] successes)
        {
            SetSuccessMessages(successes.AsEnumerable());
        }

        public void SetSuccessMessages(IEnumerable<string> successes)
        {
            ViewData[Constants.SUCCESS_MESSAGES] = successes;
        }

        public void SetErrorMessages(params string[] errors)
        {
            SetErrorMessages(errors.AsEnumerable());
        }

        public void SetErrorMessages(IEnumerable<string> errors)
        {
            ViewData[Constants.ERROR_MESSAGES] = errors;
        }

        public void AddErrorMessage(string error)
        {
            var errors = new string[] { error };

            if (ViewData[Constants.ERROR_MESSAGES] is Enumerable)
            {
                errors = Enumerable
                    .Concat(ViewData[Constants.ERROR_MESSAGES] as IEnumerable<string>, errors)
                    .ToArray();
            }

            ViewData[Constants.ERROR_MESSAGES] = errors.AsEnumerable();
        }

        public static string HashString(string str)
        {
            // https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: str,
                salt: _EncryptionSalt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}