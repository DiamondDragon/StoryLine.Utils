using System;
using StoryLine.Contracts;
using StoryLine.Utils.Contracts;

namespace StoryLine.Utils.Actions
{
    public class Transform : IActionBuilder
    {
        private IDataConverter _converter;
        private Type _type;
        private Func<object> _sourceProvider;

        public Transform From(Func<object> sourceProvider)
        {
            _sourceProvider = sourceProvider ?? throw new ArgumentNullException(nameof(sourceProvider));

            return this;
        }

        public Transform Using<T>()
            where T : IDataConverter, new()
        {
            return Using(new T());
        }

        public Transform Using(IDataConverter converter)
        {
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));

            return this;
        }

        public Transform To<T>()
        {
            return To(typeof(T));
        }

        public Transform To(Type type)
        {
            _type = type ?? throw new ArgumentNullException(nameof(type));

            return this;
        }

        public IAction Build()
        {
            return new TransformAction(_type, _sourceProvider(), _converter);
        }
    }
}
