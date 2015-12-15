using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Surface;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;

namespace SurfaceUDP
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {
        private static IPAddress localAddress = IPAddress.Parse("127.0.0.1");
        private Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private IPEndPoint ep = new IPEndPoint(localAddress, 11000);

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Occurs when the window is about to close.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            SendMessage("exit");
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
            s.Close(1);
        }

        // Use this for testing in a regular PC. Comment out while using Surface
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            Point pos = e.GetPosition(this);
            string arg = pos.X.ToString() + "," +
                         pos.Y.ToString() + "," +
                         "0";
            SendMessage("OnTouchDown", arg);
        }

        // Use this for testing in a regular PC. Comment out while using Surface
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            Point pos = e.GetPosition(this);
            string arg = pos.X.ToString() + "," +
                         pos.Y.ToString() + "," +
                         "0";
            SendMessage("OnTouchUp", arg);
        }

        // Use this for testing in a regular PC. Comment out while using Surface
        protected override void OnMouseMove(MouseEventArgs e)
        {
            Point pos = e.GetPosition(this);
            string arg = pos.X.ToString() + "," +
                         pos.Y.ToString() + "," +
                         "0";
            SendMessage("OnTouchMove", arg);
        }

        private void OnTouchDown(object sender, TouchEventArgs e)
        {
            if (e.TouchDevice.GetIsFingerRecognized())
            {
                TouchPoint tp = e.GetTouchPoint(this);

                string arg = ((int)tp.Position.X).ToString() + "," +
                             ((int)tp.Position.Y).ToString() + "," +
                             tp.TouchDevice.Id.ToString();
                Debug.WriteLine("OnTouchDown" + arg);
                SendMessage("OnTouchDown", arg);
            }
        }

        private void OnTouchMove(object sender, TouchEventArgs e)
        {
            if (e.TouchDevice.GetIsFingerRecognized())
            {
                TouchPoint tp = e.GetTouchPoint(this);

                string arg = ((int)tp.Position.X).ToString() + "," +
                             ((int)tp.Position.Y).ToString() + "," +
                             tp.TouchDevice.Id.ToString();
                SendMessage("OnTouchMove", arg);
            }
        }

        private void OnTouchUp(object sender, TouchEventArgs e)
        {
            if (e.TouchDevice.GetIsFingerRecognized())
            {
                TouchPoint tp = e.GetTouchPoint(this);

                string arg = ((int)tp.Position.X).ToString() + "," +
                             ((int)tp.Position.Y).ToString() + "," +
                             tp.TouchDevice.Id.ToString();
                //Debug.WriteLine("OnTouchUp"+arg);
                SendMessage("OnTouchUp", arg);
            }
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        // Send message to Unity3D
        private void SendMessage(string function, string arg)
        {
            byte[] sendbuf = Encoding.ASCII.GetBytes(function + "," + arg);
            s.SendTo(sendbuf, ep);
        }

        // Send message to Unity3D
        private void SendMessage(string function)
        {
            byte[] sendbuf = Encoding.ASCII.GetBytes(function);
            s.SendTo(sendbuf, ep);
        }
    }
}