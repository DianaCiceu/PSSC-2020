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

        public class QuestionPosted : IPostQuestionResult
        {
            public Guid QuestionId { get; private set; }
            public string Title { get; set; }

            public int VoteCount { get; private set; }
            public IReadOnlyCollection<VoteEnum> AllVotes { get; private set; }


             public QuestionPosted(Guid questionId, string title, IReadOnlyCollection<VoteEnum> votes,int votecount)
             {
                 AllVotes = votes;
                 VoteCount = votecount;
                 QuestionId = questionId;
                 Title = title;

             }
            public QuestionPosted(IReadOnlyCollection<VoteEnum> votes, int votecount)
            {
                AllVotes = votes;
                VoteCount = votecount;
            }

        }

        public class QuestionNotPosted : IPostQuestionResult
        {
            public string Reason { get; set; }

            public QuestionNotPosted(string reason)
            {
                Reason = reason;
            }
        }

        public class QuestionValidationFailed : IPostQuestionResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public QuestionValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    
       public enum VoteEnum
        {
            Up = 1,
            Down = -1
        }
     
        public class UpdateVotes
        {
            //adds new vote to AllVotes list and then changes the score
            public QuestionPosted Update(QuestionPosted quest, VoteEnum vote)
            {
                
                var lines = quest.AllVotes.ToList();
                lines.Add(vote);

                return new QuestionPosted(quest.QuestionId, quest.Title,lines, lines.Sum());
            }
        }
    }
}
