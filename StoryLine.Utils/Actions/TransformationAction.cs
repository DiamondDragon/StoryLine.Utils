using System;
using StoryLine.Contracts;
using StoryLine.Exceptions;
using StoryLine.Utils.Contracts;

namespace StoryLine.Utils.Actions
{
    public class TransformationAction : IAction
    {
        private readonly Type _type;
        private readonly ITextProvider _provider;
        private readonly ITextConverter _converter;

        public TransformationAction(Type type, ITextProvider provider, ITextConverter converter)
        {
            _type = type ?? throw new ArgumentNullException(nameof(type));
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        public void Execute(IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            var text = _provider.GetText();
            if (string.IsNullOrEmpty(text))
                throw new ExpectationException($"Failed to get text for artifact of type {_type}.");

            var result = _converter.Convert(text, _type);
            if (result == null)
                throw new ExpectationException($"Failed to convert text into artifact of type {_type}. Text to convert: {text}.");

            actor.Artifacts.Add(result);
        }
    }
}