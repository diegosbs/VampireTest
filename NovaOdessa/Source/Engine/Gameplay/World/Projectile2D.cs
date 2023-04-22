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
    public class Projectile2D : Basic2D
    {
        public float speed;

        public Unit owner;

        public Vector2 direction;

        public bool done;

        public TimerControl timer;

        public Projectile2D(string inputPath, Vector2 inputPos, Vector2 inputDims, Unit inputOwner, Vector2 inputTarget)
            : base(inputPath, inputPos, inputDims) {

            done = false;

            speed = 5.0f;

            owner = inputOwner;

            direction = inputTarget - owner.pos;

            direction.Normalize();

            rot = Globals.RotateTowards(pos, new Vector2(inputTarget.X, inputTarget.Y));

            timer = new TimerControl(1200);

        }

        public virtual void Update(Vector2 inputOffset, List<Unit> inputUnits) {

            pos += direction * speed;

            timer.UpdateTimer();

            if (timer.Test()){
                done = true;
            }

            if(ColisionTest(inputUnits)){
                done = true;
            }
        }

        public virtual bool ColisionTest(List<Unit> inputUnits ) {

            for(int i=0; i<inputUnits.Count; i++){
                if (Globals.GetDistance(pos, inputUnits[i].pos) < inputUnits[i].hitDistance)
                {
                    inputUnits[i].GetHit();
                    return true;
                }
            }
            
            return false;
        }

        public override void Draw(Vector2 inputOffset) {
            base.Draw(inputOffset);
        }

    }
}
