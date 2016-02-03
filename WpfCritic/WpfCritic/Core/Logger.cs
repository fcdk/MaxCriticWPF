using System;
using System.IO;
using System.Text;
using System.Windows;

namespace WpfCritic.Core
{
    public class Logger : IDisposable
    {
        private static Logger _instance;
        private BinaryWriter _writer;
        private FileStream _file;

        private Logger()
        {
            string logFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt");
            _file = File.Open(logFileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            _writer = new BinaryWriter(_file, Encoding.Default);
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
                if (_writer == null)
                    return;

                _writer.Write(string.Format("{0} | {1} | {2} | {3} | {4}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff"), level, title, message, Environment.NewLine));
            }
            catch (Exception ex)
            {
                MessageBox.Show("WriteMessage error:" + ex);
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
