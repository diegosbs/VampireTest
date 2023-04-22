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
    public class Basic2D
    {
        public float rot;
        public Vector2 pos, dims;
        public Texture2D myModel;
        
        public Basic2D(string pathInput, Vector2 posInput, Vector2 dimsInput){
            pos = posInput;
            dims = dimsInput;

            myModel = Globals.content.Load<Texture2D>(pathInput);

        }

        public virtual void Update(Vector2 inputOffset)
        {

        }

        public virtual void Draw(Vector2 inputOffset){
            if(myModel != null){
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + inputOffset.X), (int)(pos.Y + inputOffset.Y),
                (int)dims.X, (int)dims.Y), null, Color.White, rot, new Vector2(myModel.Bounds.Width/2, myModel.Bounds.Height/2),
                new SpriteEffects(),0);
            }
        }

        public virtual void Draw(Vector2 inputOffset, Vector2 inputOrigin)
        {
            if (myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + inputOffset.X), (int)(pos.Y + inputOffset.Y),
                (int)dims.X, (int)dims.Y), null, Color.White, rot, new Vector2(inputOrigin.X, inputOrigin.Y),
                new SpriteEffects(), 0);
            }
        }





    }

}