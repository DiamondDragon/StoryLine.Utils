using System;
using StoryLine.Contracts;
using StoryLine.Utils.Contracts;

namespace StoryLine.Utils.Actions
{
    public class TextTransform : IActionBuilder
    {
        private ITextConverter _converter;
        private Type _type;
        private Func<string> _textProvider;

        public TextTransform Source(Func<string> textProvider)
        {
            _textProvider = textProvider ?? throw new ArgumentNullException(nameof(textProvider));

            return this;
        }

        public TextTransform Converter<T>()
            where T : ITextConverter, new()
        {
            return Converter(new T());
        }

        public TextTransform Converter(ITextConverter converter)
        {
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));

            return this;
        }

        public TextTransform Target<T>()
        {
            return Target(typeof(T));
        }

        public TextTransform Target(Type type)
        {
            _type = type ?? throw new ArgumentNullException(nameof(type));

            return this;
        }

        public IAction Build()
        {
            return new TextTransformAction(_type, _textProvider(), _converter);
        }
    }
}
