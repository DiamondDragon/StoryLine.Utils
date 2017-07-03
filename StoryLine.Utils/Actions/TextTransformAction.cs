using System;
using StoryLine.Contracts;
using StoryLine.Exceptions;
using StoryLine.Utils.Contracts;

namespace StoryLine.Utils.Actions
{
    public class TextTransformAction : IAction
    {
        private readonly Type _type;
        private readonly string _text;
        private readonly ITextConverter _converter;

        public TextTransformAction(Type type, string text, ITextConverter converter)
        {
            _type = type ?? throw new ArgumentNullException(nameof(type));
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        public void Execute(IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            var result = _converter.Convert(_text, _type);
            if (result == null)
                throw new ExpectationException($"Failed to convert text into artifact of type {_type}. Text to convert: {_text}.");

            actor.Artifacts.Add(result);
        }
    }
}