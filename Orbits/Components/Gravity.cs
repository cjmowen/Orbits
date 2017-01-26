using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbits.Components
{
    public class Gravity: Component
    {
        public Gravity()
        {
            Flag = ComponentFlag.Gravity;
        }
    }
}
