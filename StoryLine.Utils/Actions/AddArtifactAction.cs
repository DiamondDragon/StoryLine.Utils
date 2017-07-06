using System;
using StoryLine.Contracts;

namespace StoryLine.Utils.Actions
{
    public class AddArtifactAction : IAction
    {
        private readonly object _artifact;

        public AddArtifactAction(object artifact)
        {
            _artifact = artifact ?? throw new ArgumentNullException(nameof(artifact));
        }

        public void Execute(IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            actor.Artifacts.Add(_artifact);
        }
    }
}