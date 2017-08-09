using System;
using StoryLine.Contracts;

namespace StoryLine.Utils.Actions
{
    public class AddArtifact : IActionBuilder
    {
        private Func<object> _valueFactory;

        public AddArtifact Value(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return Factory(() => value);
        }

        public AddArtifact Factory(Func<object> valueFactory)
        {
            _valueFactory = valueFactory ?? throw new ArgumentNullException(nameof(valueFactory));

            return this;
        }

        public IAction Build()
        {
            return new AddArtifactAction(_valueFactory);
        }
    }
}