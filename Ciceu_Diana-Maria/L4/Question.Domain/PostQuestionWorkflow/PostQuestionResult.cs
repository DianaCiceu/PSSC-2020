using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharp.Choices;

namespace Question.Domain.CreateQuestionWorkflow
{
    [AsChoice]
    public static partial class PostQuestionResult
    {
        public interface IPostQuestionResult { }

        public class QuestionPosted: IPostQuestionResult
        {
            public Guid QuestionId { get; private set; }
            public string Title { get; set; }
            public string Problem { get; set; }
            public string Code { get; set; }
            public string Tag { get; set; }

            public QuestionPosted(Guid questionId,string title,string problem,string code,string tag)
            {
                QuestionId = questionId;
                Title = title;
                Problem = problem;
                Code = code;
                Tag = tag;
            }
        }

        public class QuestionNotPosted: IPostQuestionResult
        {
            public string Reason { get; set; }

            public QuestionNotPosted(string reason)
            {
                Reason = reason;
            }
        }

        public class QuestionValidationFailed: IPostQuestionResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public QuestionValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}