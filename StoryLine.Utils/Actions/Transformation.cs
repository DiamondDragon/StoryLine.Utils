using System;
using StoryLine.Contracts;
using StoryLine.Utils.Contracts;

namespace StoryLine.Utils.Actions
{
    public class Transformation : IActionBuilder
    {
        private ITextConverter _converter;
        private ITextProvider _provider;
        private Type _type;

        public Transformation Provider(ITextProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));

            return this;
        }

        public Transformation Converter<T>()
            where T : ITextConverter, new()
        {
            return Converter(new T());
        }

        public Transformation Converter(ITextConverter converter)
        {
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));

            return this;
        }

        public Transformation Artifact<T>()
        {
            _type = typeof(T);

            return this;
        }

        public IAction Build()
        {
            return new TransformationAction(_type, _provider, _converter);
        }
    }
}
