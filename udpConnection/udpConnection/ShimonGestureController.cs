using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventuz.OSC;

namespace udpConnection
{
    public static class ShimonGestureController
    {
        const int port = 51973;
        const string host = "10.0.1.7";
        static UdpWriter writer;
        
        public ShimonGestureController() {
            
        }

        public static void performGesture(Gesture g)
        {
            if (writer == null)
            {
                writer = new UdpWriter(host, port);
            }
            
            var movements = g.getMovements();
            foreach (Movement m in movements)
            {
                if (m.type == DOF.PAUSE) {
                    System.Threading.Thread.Sleep((int)m.timeToPause * 1000);
                }
                else {
                    var messages = new List<OscElement>();
                    messages.Add(m.ToMessage());
                    writer.Send(new OscBundle(DateTime.Now, messages.ToArray()));
                }
            }
        }
    }
}
