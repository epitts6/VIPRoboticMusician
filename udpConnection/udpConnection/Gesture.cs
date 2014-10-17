using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventuz.OSC;

namespace udpConnection
{

    public class Gesture
    {
        List<Movement> movements;

        public Gesture()
        {
            movements = new List<Movement>();
        }

        public void addMovement(Movement m)
        {
            this.movements.Add(m);
        }

        public List<Movement> getMovements()
        {
            return this.movements;
        }
            
    }

    public class Movement
    {
        public DOF type;
        public float position;
        public float speed;
        public float timeToPause;

        public Movement(DOF d, float p, float s, float t = 0)
        {
            this.type = d;
            this.position = p;
            this.speed = s;
            this.timeToPause = t;
        }

        public Movement(DOF d, float t)
        {
            if (d == DOF.PAUSE) {
                this.timeToPause = t;
                this.type = d;
            }
            else {
                throw new InvalidOperationException();
            }
        }

        public OscElement ToMessage()
        {
            string dof = "";
            switch (this.type) {
                case DOF.BASEPAN :
                    dof = "/basePan2";
                    break;
                case DOF.HEADTILT :
                    dof = "/headTilt2";
                    break;
                case DOF.NECKPAN :
                    dof = "/neckPan2";
                    break;
                case DOF.NECKTILT :
                    dof = "/neckTilt2";
                    break;
                default :
                    Console.WriteLine("ERROR: No message should be created when pausing.");
                    break;
            }
            return new OscElement(dof, this.position, this.speed);
        }
    }

}
