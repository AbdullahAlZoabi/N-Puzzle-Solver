using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_PUZZEL
{
  public  class Point
    {
        private short x;
        private short y;
        public Point()
        {
            x = 0;
            y = 0;
        }
        public Point(short x, short y)
        {
            this.x = x;
            this.y = y;
        }
        public void setpoint(short x,short y)
        {
            this.x = x;
            this.y = y;
        }
        public short getX()
        {
            return x;

        }
        public short getY()
        {
            return y;
        }
    }
}
