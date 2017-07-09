using System;
using StoryLine.Contracts;
using StoryLine.Exceptions;

namespace StoryLine.Utils.Expectations
{
    public class ArtifactExpectation<TArtifact> : IExpectation
    {
        private readonly Func<TArtifact, bool> _filter;
        private readonly Func<TArtifact, bool> _predicate;

        public ArtifactExpectation(Func<TArtifact, bool> predicate, Func<TArtifact, bool> filter = null)
        {
            _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
            _filter = filter;
        }

        public void Validate(IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            var artifact = actor.Artifacts.Get(_filter);
            if (artifact == null)
                throw new ExpectationException($"Artifact of type {typeof(TArtifact)} was not found.");

            if (!_predicate(artifact))
                throw new ExpectationException($"Artifact of type {typeof(TArtifact)} doesn't match expectation.");
        }
    }
}