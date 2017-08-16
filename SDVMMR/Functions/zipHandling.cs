using System.IO.Compression;
using SharpCompress;
using System.IO;
using SharpCompress.Readers;
using System;

namespace SDVMMR
{
    public class zipHandling
    {
        internal static void extractZip(string sourcePath, string destPath)
        {
            //ZipFile.ExtractToDirectory(sourcePath,destPath);
            using (Stream stream = File.OpenRead(sourcePath))
            using (var reader = ReaderFactory.Open(stream))
            {
                while (reader.MoveToNextEntry())
                {
                    if (!reader.Entry.IsDirectory)
                    {
                        Console.WriteLine(reader.Entry.Key);
                        reader.WriteEntryToDirectory(destPath, new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                }
            }
        }
    }
}
