using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Authentication
{
    public class TokenProvider
    {
        private string _accessToken;

        public void SetAccessToken(string accessToken)
        {
            _accessToken = accessToken;
        }

        public string GetAccessToken()
        {
            return _accessToken;
        }
    }
}
