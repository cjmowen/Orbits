using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbits.Components
{
    class Engine: Component
    {
        private float _throttle;
        private float _maxThrust;

        public float MaxThrust
        {
            get
            {
                return _maxThrust;
            }
            private set
            {
                _maxThrust = value;
            }
        }

        public float Thrust
        {
            get
            {
                return _maxThrust * _throttle;
            }
        }

        public float Throttle
        {
            get
            {
                return _throttle;
            }
            set
            {
                // Throttle goes from 0% to 100%.
                _throttle = MathHelper.Clamp(value, 0, 1);
            }
        }

        public Engine(float maxThrust)
        {
            Flag = ComponentFlag.Engine;
            MaxThrust = maxThrust;
        }
    }
}
