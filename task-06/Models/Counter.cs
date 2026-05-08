using System;

namespace EventApp.Models
{
    public delegate void ThresholdReachedEventHandler(object sender, ThresholdReachedEventArgs e);

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }

    public class Counter
    {
        private int _threshold;
        private int _total;

        // Define the event based on the delegate
        public event ThresholdReachedEventHandler? ThresholdReached;

        public Counter(int passedThreshold)
        {
            _threshold = passedThreshold;
        }

        public void Add(int x)
        {
            _total += x;
            
            // Trigger the event when the threshold is met or exceeded
            if (_total >= _threshold)
            {
                OnThresholdReached(new ThresholdReachedEventArgs
                {
                    Threshold = _threshold,
                    TimeReached = DateTime.Now
                });
                
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            // Invoke the event if there are any subscribers
            ThresholdReached?.Invoke(this, e);
        }

        public int GetTotal()
        {
            return _total;
        }
    }
}
