using System;
using StoryLine.Contracts;

namespace StoryLine.Utils.Actions
{
    public class Wait : IActionBuilder
    {
        private TimeSpan _timeout = TimeSpan.FromSeconds(1);

        public void Timeout(TimeSpan timeout)
        {
            _timeout = timeout;
        }

        public IAction Build()
        {
            return new WaitAction(_timeout);
        }
    }
}
