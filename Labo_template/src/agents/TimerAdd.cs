using System;

using System.Windows.Controls;
using System.Windows.Forms;

namespace Labo_template.src.agents
{
    public partial class TimerAdd : Slider
    {
        private Timer t = new Timer();
        public event EventHandler SliderValueChanged;

        public void AddTimerOnSliderInit(Slider s)
        {
            t.Interval = 2000;
            t.Tick += new EventHandler(tic);

        }

        private void tic(object sender, EventArgs e)
        {
            t.Stop();
            OnValueChangedDelayed();
        }


        protected override void OnValueChanged(double oldValue, double newValue)
        {
            base.OnValueChanged(oldValue, newValue);
            t.Stop();
            t.Start();
        }

        protected virtual void OnValueChangedDelayed()
        {
            if (SliderValueChanged != null)
            {
                SliderValueChanged(this, EventArgs.Empty);
            }
        }

        public int ValueChangedDelayedInterval
        {
            get { return t.Interval; }
            set { t.Interval = value; }
        }


    }
}
