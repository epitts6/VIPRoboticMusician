using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace udpConnection
{
    public static class GestureLibrary
    {
       public static Gesture Nod()
        {
            float Ntstart = 0.4f;
            float hTmax = 1.2f;
            float Ntmax = 0.3f;
            float hTmin = -1.2f;
            float Ntmin = -0.3f;
            float hTspeed = 20f;
            float Ntspeed = 6f;
            float pauseTime = 1.9f;

            //Movement m1 = new Movement(DOF.HEADTILT, 0.0f, hTspeed);
            //Movement p1 = new Movement(DOF.PAUSE, pauseTime);

            //Movement m2 = new Movement(DOF.NECKTILT, Ntstart, Ntspeed);
            //Movement p2 = new Movement(DOF.PAUSE, pauseTime);
            //Movement m3 = new Movement(DOF.HEADTILT, hTmin, hTspeed);
            //Movement p3 = new Movement(DOF.PAUSE, pauseTime);

            Movement m4 = new Movement(DOF.NECKTILT, Ntmin, Ntspeed);
            Movement m5 = new Movement(DOF.HEADTILT, hTmin, hTspeed);
            Movement p4 = new Movement(DOF.PAUSE, pauseTime);

            Movement m6 = new Movement(DOF.NECKTILT, Ntmax, Ntspeed);
            Movement m7 = new Movement(DOF.HEADTILT, hTmax, hTspeed);
            Movement p5 = new Movement(DOF.PAUSE, pauseTime);

            Movement m8 = new Movement(DOF.NECKTILT, Ntmin, Ntspeed);
            Movement m9 = new Movement(DOF.HEADTILT, hTmin, hTspeed);
            Movement p6 = new Movement(DOF.PAUSE, pauseTime);

            Movement m10 = new Movement(DOF.NECKTILT, Ntmax, Ntspeed);
            Movement m11 = new Movement(DOF.HEADTILT, hTmax, hTspeed);
            Movement p7 = new Movement(DOF.PAUSE, pauseTime);

            Gesture g = new Gesture();
            //g.addMovement(m1);
            //g.addMovement(p1);

            //g.addMovement(m2);
            //g.addMovement(p2);
            //g.addMovement(m3);
            //g.addMovement(p3);

            g.addMovement(m4);
            g.addMovement(m5);
            g.addMovement(p4);

            g.addMovement(m6);
            g.addMovement(m7);
            g.addMovement(p5);

            g.addMovement(m8);
            g.addMovement(m9);
            g.addMovement(p6);

            g.addMovement(m10);
            g.addMovement(m11);
            g.addMovement(p7);
            return g;
        }
    }
}
