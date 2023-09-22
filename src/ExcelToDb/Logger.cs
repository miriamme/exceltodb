using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDb
{
    public class Logger
    {
        private readonly RichTextBox textBox;

        public Logger(RichTextBox textBox)
        {
            this.textBox = textBox;
        }

        public void LogDebug(string message)
        {
            this.Log(message, LogType.Debug);
        }

        public void LogInformation(string message)
        {
            this.Log(message, LogType.Info);
        }

        public void LogWarning(string message)
        {
            this.Log(message, LogType.Warning);
        }

        public void LogError(string message)
        {
            this.Log(message, LogType.Error);
        }

        private void Log(string message, LogType logType)
        {
            switch (logType)
            {
                case LogType.Debug:
                    textBox.SelectionColor = Color.Green;
                    break;
                case LogType.Info:
                    textBox.SelectionColor = Color.Blue;
                    break;
                case LogType.Warning:
                    textBox.SelectionColor = Color.DarkRed;
                    break;
                case LogType.Error:
                    textBox.SelectionColor = Color.Red;
                    break;
                default:
                    break;
            }
            string log = $" {DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logType}] {message}\r\n";
            textBox.AppendText(log);
            textBox.Select(textBox.Text.Length, 0);
            textBox.ScrollToCaret();
        }
    }
}
