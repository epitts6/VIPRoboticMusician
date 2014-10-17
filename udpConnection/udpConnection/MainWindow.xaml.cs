using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ventuz.OSC;


namespace udpConnection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UdpUser client;
        UdpWriter writer;

        public MainWindow()
        {
            InitializeComponent();
            int port = 51973;
            string host = "10.0.1.7";

            //client = UdpUser.ConnectTo(host, port);

            writer = new UdpWriter(host, port);
        }

  

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (messageTxtBox.Text != "")
            {
                //client.Send(messageTxtBx.Text);
                //OscMessage message = new OscMessage()
                var messages = new List<OscElement>();

                if ((bool)basePan.IsChecked)
                {
                    messages.Add(new OscElement("/basePan2", float.Parse(basePanPosition.Text), float.Parse(basePanSpeed.Text)));
                } 
                
                if ((bool)neckTilt.IsChecked)
                {
                    messages.Add(new OscElement("/neckTilt2", float.Parse(neckTiltPosition.Text), float.Parse(neckTiltSpeed.Text)));
                } 
                
                if ((bool)neckPan.IsChecked)
                {
                    messages.Add(new OscElement("/neckPan2", float.Parse(neckPanPosition.Text), float.Parse(neckPanSpeed.Text)));
                }

                if ((bool)headTilt.IsChecked)
                {
                    messages.Add(new OscElement("/headTilt2", float.Parse(headTiltPosition.Text), float.Parse(headTiltSpeed.Text)));   
                }
               


                //messages.Add(new OscElement("/basePan", double.Parse(messageTxtBox.Text)));
                //messages.Add(new OscElement("/basePan", 1.2));
                writer.Send(new OscBundle(DateTime.Now, messages.ToArray()));
                //float position = float.Parse(messageTxtBox.Text);
                //float speed = 0.5f;
                //List<float> pack = new List<float>();
                //                string args = messageTxtBox.Text;
                
                //writer.Send(new OscElement("/basePan2", args));
            }
        }

        private void messageTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Nod_Click(object sender, RoutedEventArgs e)
        {
            Movement m1 = new Movement(DOF.HEADTILT, -0.5f, 2f);
            Movement p1 = new Movement(DOF.PAUSE, 0.5f);
            Movement m2 = new Movement(DOF.HEADTILT, 0f, 2f);
            Gesture g = new Gesture();
            g.addMovement(m1);
            g.addMovement(p1);
            g.addMovement(m2);

            ShimonGestureController.performGesture(g);
        }

    }
}


