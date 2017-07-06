using System;
using StoryLine.Contracts;

namespace StoryLine.Utils.Actions
{
    public class AddArtifact : IActionBuilder
    {
        private object _value;

        public AddArtifact Value(object value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));

            return this;
        }

        public IAction Build()
        {
            return new AddArtifactAction(_value);
        }
    }
}