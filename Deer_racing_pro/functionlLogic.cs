using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deer_racing_pro
{
  public  class functionlLogic
    {
        Random rd = new Random();
        public int moveDeer()
        {
            return rd.Next(1, 50);
        }

        public int stpTimer() {
            return 980;
        }
    }
}
