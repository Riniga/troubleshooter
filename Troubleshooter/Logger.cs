using System;
using System.Windows.Forms;

namespace Troubleshooter
{
    public sealed class Logger
    {
        private ListBox log;
        private static readonly Lazy<Logger> lazy = new Lazy<Logger> (() => new Logger());
        public static Logger Instance { get { return lazy.Value; } }

        private Logger(){ log= new ListBox();}

        public void SetLoggerListBox(ListBox loggerListBox)
        {
            log = loggerListBox;
            log.Items.Clear();
        }

        public void Log(string message)
        {
            log.Items.Add(DateTime.Now.ToString("HH:mm:ss") + ": " + message);
        }
    }
}
