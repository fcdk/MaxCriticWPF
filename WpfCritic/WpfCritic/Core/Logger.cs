using System;
using System.IO;
using System.Text;
using System.Windows;

namespace WpfCritic.Core
{
    public class Logger : IDisposable
    {
        private static Logger _instance;
        private StreamWriter _writer;
        private FileStream _file;
        private bool _errorOffWrite = false;

        private Logger()
        {
            //путь к лог-файлу: C:\Users\{USERNAME}\AppData\Roaming\MaxCritic\Log.txt
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MaxCritic");
            string logFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\MaxCritic", "Log.txt");
            _file = File.Open(logFileName, FileMode.Append, FileAccess.Write, FileShare.None);
            _writer = new StreamWriter(_file, Encoding.Default);
        }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Logger();
                return _instance;
            }
        }

        public static void Error(string title, string message)
        {
            Instance.WriteMessage("ERROR", title, message);
        }

        public static void Warning(string title, string message)
        {
            Instance.WriteMessage("Warning", title, message);
        }

        public static void Info(string title, string message)
        {
            Instance.WriteMessage("Info", title, message);
        }

        private void WriteMessage(string level, string title, string message)
        {
            try
            {
                if (_writer == null || _errorOffWrite)
                    return;

                _writer.Write(string.Format("{0} | {1} | {2} | {3} | {4}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff"), level, title, message, Environment.NewLine));
            }
            catch (Exception ex)
            {
                var result = MessageBox.Show("Проблема з записом логів в файл, зверніться до адміністратора!" + Environment.NewLine + ex 
                + Environment.NewLine + Environment.NewLine + "Більше не показувати це повідомлення (відключити логування)?",
                "ERROR", MessageBoxButton.YesNo, MessageBoxImage.Error);

                if (result == MessageBoxResult.Yes)
                    _errorOffWrite = true;
            }
        }

        public void Dispose()
        {
            if (_writer != null)
            {
                _writer.Flush();
                _writer.Close();
            }
            if (_file != null)
                _file.Close();
        }
    }
}
