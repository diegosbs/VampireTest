#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace NovaOdessa
{
    public class Unit : Basic2D
    {
        
        public float speed, hitDistance;

        public bool dead;

        public Unit(string inputPath, Vector2 inputPos, Vector2 inputDims): base(inputPath, inputPos, inputDims){
            dead = false;
            speed = 2.0f;

            hitDistance = 35.0f;
        }

        public override void Update(Vector2 inputOffset)
        {

            base.Update(inputOffset);
        }


        public virtual void GetHit()
        {
            dead = true;
        }

        public override void Draw(Vector2 inputOffset){
            base.Draw(inputOffset);
        }





    }

}