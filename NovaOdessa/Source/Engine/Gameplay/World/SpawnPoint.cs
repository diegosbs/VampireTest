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
    public class SpawnPoint : Basic2D
    {
        
        public float hitDistance;

        public bool dead;

        public TimerControl spawnTimer = new TimerControl(2200);

        public SpawnPoint(string inputPath, Vector2 inputPos, Vector2 inputDims): base(inputPath, inputPos, inputDims){
            dead = false;

            hitDistance = 35.0f;
        }

        public override void Update(Vector2 inputOffset)
        {
            spawnTimer.UpdateTimer();
            if (spawnTimer.Test())
            {
                SpawnMob();
                spawnTimer.ResetToZero();
            }


            base.Update(inputOffset);
        }


        public virtual void GetHit()
        {
            dead = true;
        }

        public virtual void SpawnMob()
        {
            GameGlobals.PassMob(new Imp(new Vector2(pos.X, pos.Y)));
        }

        public override void Draw(Vector2 inputOffset){
            base.Draw(inputOffset);
        }





    }

}