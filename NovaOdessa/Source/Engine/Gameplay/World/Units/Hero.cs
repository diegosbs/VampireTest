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
    public class Hero : Unit
    {

        public Hero(string inputPath, Vector2 inputPos, Vector2 inputDims): base(inputPath, inputPos, inputDims){
            speed = 2.0f;
        }

        public override void Update(Vector2 inputOffset)
        {
            if(Globals.keyboard.GetPress("A")){
                pos = new Vector2(pos.X -speed, pos.Y);
            }
            if(Globals.keyboard.GetPress("D")){
                pos = new Vector2(pos.X +speed, pos.Y);
            }
            if(Globals.keyboard.GetPress("W")){
                pos = new Vector2(pos.X, pos.Y -speed);
            }
            if(Globals.keyboard.GetPress("S")){
                pos = new Vector2(pos.X, pos.Y +speed);
            }

            rot = Globals.RotateTowards(pos, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y));

            if (Globals.mouse.LeftClick()) {
                GameGlobals.PassProjectile(new Fireball(new Vector2(pos.X,pos.Y), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y)));
            }


            base.Update(inputOffset);
        }

        public override void Draw(Vector2 inputOffset){
            base.Draw(inputOffset);
        }





    }

}