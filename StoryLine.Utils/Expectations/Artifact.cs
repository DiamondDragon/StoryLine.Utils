using System;
using StoryLine.Contracts;

namespace StoryLine.Utils.Expectations
{
    public class Artifact<TArtifact> : IExpectationBuilder
    {
        private Func<TArtifact, bool> _filter;
        private Func<TArtifact, bool> _validator;

        public Artifact<TArtifact> Filter(Func<TArtifact, bool> filter)
        {
            _filter = filter ?? throw new ArgumentNullException(nameof(filter));

            return this;
        }

        public Artifact<TArtifact> Meets(Action<TArtifact> validator)
        {
            if (validator == null)
                throw new ArgumentNullException(nameof(validator));

            return Meets(x =>
            {
                validator(x);
                return true;
            });
        }

        public Artifact<TArtifact> Meets(Func<TArtifact, bool> validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));

            return this;
        }

        public IExpectation Build()
        {
            if (_validator == null)
                throw new InvalidOperationException($"Method {nameof(Meets)}() must be called before {nameof(Build)}() is invoked.");

            return new ArtifactExpectation<TArtifact>(_validator, _filter);
        }
    }
}
