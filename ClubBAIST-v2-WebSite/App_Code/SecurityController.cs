using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for SecurityController
/// </summary>
public class SecurityController : IPrincipal
{
    //admin
    //Kr2WN9ExfdIEc6w1yIx7vXL0oqw=
    //ZXlmPD8=
    //1
    //1
    private IIdentity _identity;
    private string[] _roles;

    public SecurityController(IIdentity identity, string[] roles)
    {
        _identity = identity;
        _roles = new string[roles.Length];
        roles.CopyTo(_roles, 0);
        Array.Sort(_roles);
    }

    public bool IsInRole(string role)
    {
        return Array.BinarySearch(_roles, role) >= 0 ? true : false;
    }

    public IIdentity Identity
    {
        get
        {
            return _identity;
        }
    }

    public bool IsInAllRoles(params string[] roles)
    {
        foreach (string searchrole in roles)
        {
            if (Array.BinarySearch(_roles, searchrole) < 0)
                return false;
        }
        return true;
    }

    public bool IsInAnyRoles(params string[] roles)
    {
        foreach (string searchrole in roles)
        {
            if (Array.BinarySearch(_roles, searchrole) >= 0)
                return true;
        }
        return false;
    }

    public string HashMaster(string textForHash, string salt)
    {
        SHA1Managed sha1 = new SHA1Managed();
        textForHash = textForHash + salt;
        byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(textForHash));
        return Convert.ToBase64String(hash);
    }

    public string MakeSalt()
    {
        RNGCryptoServiceProvider cryptoNinja = new RNGCryptoServiceProvider();
        byte[] salt = new byte[5];
        cryptoNinja.GetBytes(salt);
        return Convert.ToBase64String(salt);
    }
}