using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbits.Components
{
    [FlagsAttribute] // This allows us to use the enum in bitwise operations.
    public enum ComponentFlag
    {
        None = 0,
        Graphics = 1,
        Input =    1 << 1,
        Position = 1 << 2,
        Movement = 1 << 3,
        Mass =     1 << 4,
        Gravity =  1 << 5,
        Engine =   1 << 6,
        Size =     1 << 7
    }
}
