using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class PlayerInputs
    {
       
        List<bool> inputs = new List<bool>() { false, false, false };

        public List<bool> CheckInputs()
        {
            
            if (Engine.GetKey(Keys.LEFT))
            {
                inputs[0]=true;
            }
            else
            {
                inputs[0] = false;
            }

            if (Engine.GetKey(Keys.RIGHT))
            {
                inputs[1] = true;
            }
            else
            {
                inputs[1] = false;
            }
        




            //pasar de nivel
            if (Engine.GetKey(Keys.P))
            {
                inputs[2] = true;
            }
            else
            {
                inputs[2] = false;
            }

            return inputs;
        }
    }
}
