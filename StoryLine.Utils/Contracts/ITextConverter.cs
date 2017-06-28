using System;

namespace StoryLine.Utils.Contracts
{
    public interface ITextConverter
    {
        object Convert(string text, Type type);
    }
}