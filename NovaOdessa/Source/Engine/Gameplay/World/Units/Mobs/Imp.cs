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
    public class Imp : Unit
    {

        public Imp( Vector2 inputPos): base("2d\\Units\\Mobs\\Imp", inputPos, new Vector2(40, 40)){
            speed = 2.0f;
        }

        public virtual void Update(Vector2 inputOffset, Hero inputHero)
        {

            AI(inputHero);
            base.Update(inputOffset);
        }

        public virtual void AI(Hero inputHero)
        {
            pos += Globals.RadialMovement(inputHero.pos, pos, speed);
            rot = Globals.RotateTowards(pos, inputHero.pos);
        }

        public override void Draw(Vector2 inputOffset){
            base.Draw(inputOffset);
        }





    }

}