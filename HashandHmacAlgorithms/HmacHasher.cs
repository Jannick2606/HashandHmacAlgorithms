using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashandHmacAlgorithms
{
    internal class HmacHasher
    {
        private const int keySize = 32;
        public byte[] GenerateKey()
        {
            using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
            {
                byte[] randomNumber = new byte[keySize];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        public byte[] ComputeMd5(byte[] toBeHashed, byte[] key)
        {
            using(HMACMD5 hmac = new HMACMD5(key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }
        public byte[] ComputeHmacSha1(byte[] toBeHashed, byte[] key)
        {
            using(HMACSHA1 hmac = new HMACSHA1(key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }
        public byte[] ComputeHmacsha256(byte[] toBeHashed, byte[] key)
        {
            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }
        public byte[] ComputeHmacsha384(byte[] toBeHashed, byte[] key)
        {
            using (HMACSHA384 hmac = new HMACSHA384(key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }
        public byte[] ComputeHmacsha512(byte[] toBeHashed, byte[] key)
        {
            using(HMACSHA512 hmac = new HMACSHA512(key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }
    }
}
