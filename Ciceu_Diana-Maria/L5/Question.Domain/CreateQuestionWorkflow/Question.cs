using CSharp.Choices;
using LanguageExt.Common;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System;
namespace Question.Domain.CreateQuestionWorkflow
{
   
    public class InvalidQuestionException : Exception
    {
        public InvalidQuestionException()
        {
        }

        public InvalidQuestionException(string text) : base($"The value of the \"{text}\" field is invalid.")
        {
        }

    }

    [AsChoice]
    public static partial class Question
    {
        public interface IQuestion { }

        public class UnverifiedQuestion:IQuestion
        {
            public string Title { get; private set; }
            public string Text { get; private set; }
            public string[] Tag { get; private set; }

            private UnverifiedQuestion(string title, string text,string[] tag)
            {
                Title = title;
                Text = text;
                Tag = tag;
            }
            public static Result<UnverifiedQuestion> Create(string title, string text, string[] tag)
            {
                // if (IsQuestionValid(title,text,tag))
                if (title.Length >= 6 && title.Length <= 20)
                {
                    if (text.Length >= 6 && text.Length <= 1000)
                    {
                        if (tag.Length >= 1 && tag.Length <= 3)
                            return new UnverifiedQuestion(title, text, tag);
                        else
                            return new Result<UnverifiedQuestion>(new InvalidQuestionException("tag"));
                    }
                    else
                        return new Result<UnverifiedQuestion>(new InvalidQuestionException("text"));
                }
                else
                    return new Result<UnverifiedQuestion>(new InvalidQuestionException("title"));
            }

        }
    }
}
