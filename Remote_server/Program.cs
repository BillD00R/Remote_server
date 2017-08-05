using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    // State object for reading client data asynchronously
    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    static class Program
    {
        public static Form1 theForm;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            theForm = new Form1();

            AsynchronousSocketListener listener = new AsynchronousSocketListener(WriteLine);

            Thread thread = new Thread(listener.StartListening);
            thread.Start();

            theForm.WriteLine("Here we are");

            Application.Run(theForm);
        }

        static void WriteLine(String text)
        {
            theForm.WriteLine(text);
        }
    }
}
