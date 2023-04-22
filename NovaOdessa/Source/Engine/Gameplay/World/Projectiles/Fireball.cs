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
    public class Fireball : Projectile2D
    {

        public Fireball(Vector2 inputPos, Unit inputOwner, Vector2 inputTarget)
            : base("2d\\Projectiles\\Fireball", inputPos, new Vector2(20,20), inputOwner, inputTarget) {


        }

        public override void Update(Vector2 inputOffset, List<Unit> inputUnits) {

            base.Update(inputOffset, inputUnits);
        }

        public override void Draw(Vector2 inputOffset)
        {
            base.Draw(inputOffset);
        }
    }
}
