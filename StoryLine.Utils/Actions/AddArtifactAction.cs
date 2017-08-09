using System;
using StoryLine.Contracts;

namespace StoryLine.Utils.Actions
{
    public class AddArtifactAction : IAction
    {
        private readonly Func<object> _valueFactory;

        public AddArtifactAction(Func<object> valueFactory)
        {
            _valueFactory = valueFactory ?? throw new ArgumentNullException(nameof(valueFactory));
        }

        public void Execute(IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            actor.Artifacts.Add(_valueFactory());
        }
    }
}