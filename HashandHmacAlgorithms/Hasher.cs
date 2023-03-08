using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashandHmacAlgorithms
{
    internal class Hasher
    {
        public byte[] ComputeMd5(byte[] toBeHashed)
        {
            using (MD5 md5 = MD5.Create())
            {
                return md5.ComputeHash(toBeHashed);
            }
        }
        public byte[] ComputeSha1(byte[] toBeHashed)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(toBeHashed);
            }
        }
        public byte[] ComputeSha256(byte[] toBeHashed)
        {
            using(SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(toBeHashed);
            }
        }
        public byte[] ComputeSha384(byte[] toBeHashed)
        {
            using(SHA384 sha384 = SHA384.Create())
            {
                return sha384.ComputeHash(toBeHashed);
            }
        }
        public byte[] ComputeSha512(byte[] toBeHashed)
        {
            using(SHA512 sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(toBeHashed);
            }
        }
    }
}
