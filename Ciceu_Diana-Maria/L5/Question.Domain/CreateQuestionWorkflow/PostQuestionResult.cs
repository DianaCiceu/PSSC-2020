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

            // public int VoteCount { get; private set; }
            // public IReadOnlyCollection<VoteEnum> AllVotes { get; private set; }
            public QuestionPosted(Guid questionId, string title)
            {
             
                QuestionId = questionId;
                Title = title;

            }

            /* public QuestionPosted(Guid questionId, string title, IReadOnlyCollection<VoteEnum> votes,int votecount)
             {
                 AllVotes = votes;
                 VoteCount = votecount;
                 QuestionId = questionId;
                 Title = title;

             }*/

            /*
            public QuestionPosted(Guid questionId,string title,string text,string[] tag)
            {
                QuestionId = questionId;
                Title = title;
                Text = text;              
                Tag = tag;
            }*/
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
       /* public enum VoteEnum
        {
            Up = 1,
            Down = -1
        }
        public class Votes
        {
            public int VoteCount { get; private set; }
            public IReadOnlyCollection<VoteEnum> AllVotes { get; private set; }
            public Votes(IReadOnlyCollection<VoteEnum> votes, int votecount)
            {
                AllVotes = votes;
                VoteCount = votecount;

            }
        }
        public class UpdateVotes
        {
            //
            public QuestionPosted Update(QuestionPosted quest, int qId, decimal newSum)
            {
                //var newLines = quest.AllVotes.Where(line => line.OrderLineId != lineId).ToList();
               // var lineToBeUpdated = quest.AllVotes.First(line => line.OrderLineId == lineId);
               // var newLine = new VoteEnum(lineId, lineToBeUpdated.ProductId, newPrice);
               // newLines.Add(newLine);

                return new QuestionPosted(newLines, newLines.Sum(line => line.Price));
            }*/
        }
    }
}