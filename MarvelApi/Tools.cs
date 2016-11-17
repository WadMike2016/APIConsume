using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MarvelApi
{
    public static class Tools
    {
        /// <summary>
        /// Calculates the md5 as on marvel documentation
        /// </summary>
        /// <param name="key">The private key</param>
        /// <param name="ts">A timespan</param>
        /// <returns>the has to send to web api</returns>
        /// <remarks>
        /// Server-side applications must pass two parameters in addition to the apikey parameter:
        /// ts - a timestamp(or other long string which can change on a request-by-request basis)
        /// hash - a md5 digest of the ts parameter, your private key and your public key(e.g.md5(ts+privateKey+publicKey)
        /// For example, a user with a public key of "1234" and a private key of "abcd" could construct a valid call as follows: http://gateway.marvel.com/v1/comics?ts=1&apikey=1234&hash=ffd275c5130566a2916217b101f26150 (the hash value is the md5 digest of 1abcd1234)
        /// </remarks>
        public static string CalculateMD5LikeMarvel(TimeSpan ts, string key)
        {

            string sentenceToHash =ts.ToString().Replace(":", "").Replace(".", "") + key;

            return CalculateMD5Hash(sentenceToHash);
        }


        /// <summary>
        /// Calculates the md5 hash.
        /// </summary>
        /// <param name="input">The input to hash with MD5 Algo.</param>
        /// <returns>The hash</returns>
        public static string CalculateMD5Hash(string input)

        {

            // step 1, calculate MD5 hash from input

            MD5 md5 = MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);


            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString();

        }


        public static void DownloadRemoteImageFile(string uri, string fileName)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Check that the remote file was found. The ContentType
            // check is performed since a request for a non-existent
            // image file might be redirected to a 404-page, which would
            // yield the StatusCode "OK", even though the image was not
            // found.
            if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect) &&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            {

                // if the remote file was found, download oit
                using (Stream inputStream = response.GetResponseStream())
                using (Stream outputStream = File.OpenWrite(fileName))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                }
            }
        }

    }
}
