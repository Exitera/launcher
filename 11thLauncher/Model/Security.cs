﻿using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace _11thLauncher.Model
{
    internal static class Security
    {
        internal static string EncryptPassword(string text)
        {
            byte[] original = Encoding.Unicode.GetBytes(text);
            byte[] encrypted = ProtectedData.Protect(original, GetEntropy(), DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encrypted);
        }

        internal static string DecryptPassword(string text)
        {
            byte[] encrypted = Convert.FromBase64String(text);
            byte[] original = ProtectedData.Unprotect(encrypted, GetEntropy(), DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(original);
        }

        private static byte[] GetEntropy()
        {
            var assembly = typeof(Program).Assembly;
            var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
            var guid = attribute.Value;

            SHA512 sha512 = SHA512.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(guid);
            byte[] hash = sha512.ComputeHash(bytes);

            return hash;
        }
    }
}
