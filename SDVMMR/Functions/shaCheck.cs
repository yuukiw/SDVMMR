using System;
using System.IO;
using System.Security.Cryptography;


namespace SDVMMR
{
	public class shaCheck
	{

		public bool checksum(string Path, string checkValue)
		{
			if (checkValue != GetHashCode(Path, new SHA1CryptoServiceProvider()))
			{
				return false;
			}
			else
			{
				return true;
			}
		}


		internal static string GetHashCode(string filePath, HashAlgorithm cryptoService)

		{
			// create or use the instance of the crypto service provider

			// this can be either MD5, SHA1, SHA256, SHA384 or SHA512

			using (cryptoService)

			{

				using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					var hash = cryptoService.ComputeHash(fileStream);
					var hashString = Convert.ToBase64String(hash);
					return hashString.TrimEnd('=');
				}
			}
		}
	}
}

