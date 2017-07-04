using System;
using StoryLine.Contracts;
using StoryLine.Exceptions;
using StoryLine.Utils.Contracts;

namespace StoryLine.Utils.Actions
{
    public class TransformAction : IAction
    {
        private readonly Type _type;
        private readonly object _data;
        private readonly IDataConverter _converter;

        public TransformAction(Type type, object data, IDataConverter converter)
        {
            _type = type ?? throw new ArgumentNullException(nameof(type));
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        public void Execute(IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            var result = _converter.Convert(_data, _type);
            if (result == null)
                throw new ExpectationException($"Failed to convert data into artifact of type {_type}. Text to convert: {_data}.");

            actor.Artifacts.Add(result);
        }
    }
}