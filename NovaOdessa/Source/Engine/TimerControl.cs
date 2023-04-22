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
    public class TimerControl
    {
        public bool goodToGo;
        protected int sec;
        protected TimeSpan timer = new TimeSpan();

        public TimerControl(int m) {
            goodToGo = false;
            sec = m;
        }

        public TimerControl(int m, bool inputStartLoaded) {
            goodToGo = inputStartLoaded;
            sec = m;
        }

        public int Sec {
            get { return sec; }
            set { sec = value; }
        }

        public int Timer {
            get { return (int)timer.TotalMilliseconds; }
        }

        public void UpdateTimer() {
            timer += Globals.gameTime.ElapsedGameTime;
        }

        public void UpdateTimer(float inputSpeed) {
            timer += TimeSpan.FromTicks((long)(Globals.gameTime.ElapsedGameTime.Ticks * inputSpeed));
        }

        public virtual void AddToTimer(int inputSec) {
            timer += TimeSpan.FromMilliseconds((long)inputSec);
        }

        public bool Test() {
            if(timer.TotalMilliseconds >= sec || goodToGo){
                return true;
            }
            else{
                return false;
            }
        }

        public void Reset() {
            timer = timer.Subtract(new TimeSpan(0, 0, sec / 60000, sec / 1000, sec % 1000));
            if(timer.TotalMilliseconds < 0) {
                timer = TimeSpan.Zero;
            }
            goodToGo = false;
        }

        public void Reset(int inputNewTimer) {
            timer = TimeSpan.Zero;
            sec = inputNewTimer;
            goodToGo=false;
        }

        public void ResetToZero() {
            timer = TimeSpan.Zero;
            goodToGo = false;
        }

        public virtual XElement ReturnXml() {
            var xml = new XElement("Timer",
                                new XElement("sec", sec),
                                new XElement("timer", timer));
            return xml;
        }

        public void SetTimer(TimeSpan inputTime) {
            timer = inputTime;
        }

        public virtual void SetTimer(int inputSec) {
            timer = TimeSpan.FromMilliseconds(inputSec);
        }





    }
}
