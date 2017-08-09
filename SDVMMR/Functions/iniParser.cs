using System.IO;
using IniParser;

namespace SDVMMR
{
	public class iniParsing
	{

		public static string INI_ReadValueFromFile(string strSection, string strKey, string strDefault, string strFile)
		{
			if (!File.Exists(strFile))
			{
				FileStream fs = File.Create(strFile);
				fs.Close();
				return (strDefault);
			}
			var Parser = new FileIniDataParser();
			var Data = Parser.ReadFile(strFile);
			string result = System.Convert.ToString(Data[strSection][strKey]);
			if (string.IsNullOrEmpty(result))
			{
				return (strDefault);
			}
			else
			{
				return (result);
			}
		}

		public static void INI_WriteValueToFile(string strSection, string strKey, string strValue, string strFile)
		{

			var Parser = new FileIniDataParser();
			var Data = Parser.ReadFile(strFile);
			Data[strSection][strKey] = strValue;
			Parser.WriteFile(strFile, Data, null);
			return;
		}
	}
}