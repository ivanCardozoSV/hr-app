using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface ISecurityTokenProvider
    {
        string BuildSecurityToken(string userName, List<(string claimType, bool authValue)> claims);
    }
}
