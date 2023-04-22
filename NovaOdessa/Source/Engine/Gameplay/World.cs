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
    public class World
    {
        public Vector2 offset;

        public Hero hero;

        public List<Mob> mobs = new List<Mob>();

        public List<Projectile2D> projectiles = new List<Projectile2D>();

        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

        public World()
        {
            hero = new Hero("2d\\Hero", new Vector2(300, 300), new Vector2(48, 48));

            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassMob = AddMob;

            offset = new Vector2(0, 0);

            spawnPoints.Add(new SpawnPoint("2d\\Misc\\circle", new Vector2(50, 50), new Vector2(35, 35)));
            spawnPoints.Add(new SpawnPoint("2d\\Misc\\circle", new Vector2(Globals.screenWidth / 2, 50), new Vector2(35, 35)));

            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(500);

            spawnPoints.Add(new SpawnPoint("2d\\Misc\\circle", new Vector2(Globals.screenWidth - 50, 50), new Vector2(35, 35)));

            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(1000);

        }

        public virtual void Update()
        {
            hero.Update(offset);

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Update(offset);
            }

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(offset, mobs.ToList<Unit>());

                if (projectiles[i].done)
                {
                    projectiles.RemoveAt(i);
                    i--;
                }

            }

            for (int i = 0; i < mobs.Count; i++)
            {
                mobs[i].Update(offset);

                if (mobs[i].dead)
                {
                    mobs.RemoveAt(i);
                    i--;
                }

            }
        }

        public virtual void AddProjectile(object projectileInfo)
        {
            projectiles.Add((Projectile2D)projectileInfo);
        }

        public virtual void AddMob(object mobInfo)
        {
            mobs.Add((Mob)mobInfo);
        }

        public virtual void Draw(Vector2 inputOffset)
        {
            hero.Draw(inputOffset);

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Update(offset);
            }

            for (int i = 0; i < mobs.Count; i++)
            {
                mobs[i].Draw(offset);
            }
        }

        public static T GetPropertyValue<T>(object obj, string propName)
        {
            return (T)obj.GetType().GetProperty(propName).GetValue(obj, null);
        }
    }
}