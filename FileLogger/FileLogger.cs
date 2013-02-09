using System.IO;

namespace Logger
{
    public class FileLogger
    {
        const string STR_Debug_Format = "DEBUG: {0}";

        static string STR_FileName = "app_log.txt";
        public static string FileName
        {
            get { return STR_FileName; }
            set { STR_FileName = value; }
        }

        public static void Debug(string text)
        {
            var debugText = string.Format(STR_Debug_Format, text);
            var iso = System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication();
            var openFile = iso.OpenFile(STR_FileName, FileMode.OpenOrCreate);
            if (openFile.Length > 0)
            {
                openFile.Seek(openFile.Length - 1, SeekOrigin.Current);
            }

            using (var sw = new StreamWriter(openFile))
            {
                sw.WriteLine();
                sw.WriteLine(debugText);
            }
        }
    }
}
