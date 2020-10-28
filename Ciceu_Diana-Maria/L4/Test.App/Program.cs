
using System;
using System.Collections.Generic;
using System.Net;
using Question.Domain.CreateQuestionWorkflow;
using static Question.Domain.CreateQuestionWorkflow.PostQuestionResult;

namespace Test.App
{
    class Program
    {
        static void Main(string[] args)
        {

            var cmd = new PostQuestionCmd("Problem with class definition", "Errors keep appearing when defining class", "code1", "C#");
			var result = PostQuestion(cmd);
            result.Match(
                    ProcessQuestionPosted,
                    ProcessQuestionNotPosted,
                    ProcessInvalidQuestion
                );
			

            Console.ReadLine();
        }

        private static IPostQuestionResult ProcessInvalidQuestion(QuestionValidationFailed validationErrors)
        {
            Console.WriteLine("Profile validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        private static IPostQuestionResult ProcessQuestionNotPosted(QuestionNotPosted questionNotPostedResult)
        {
            Console.WriteLine($"Question not posted: {questionNotPostedResult.Reason}");
            return questionNotPostedResult;
        }

        private static IPostQuestionResult ProcessQuestionPosted(QuestionPosted question)
        {
            Console.WriteLine($"Question {question.QuestionId} \nTitle: {question.Title}\nProblem: {question.Problem}\nCode: {question.Code}\nTag: {question.Tag}");
            return question;
        }

        public static IPostQuestionResult PostQuestion(PostQuestionCmd postQuestionCommand)
        {
            if (string.IsNullOrWhiteSpace(postQuestionCommand.Title))
            {
                var errors = new List<string>() { "Invalid title "};
                return new QuestionValidationFailed(errors);
            }

   
            var questionId = Guid.NewGuid();
            var result = new QuestionPosted(questionId, postQuestionCommand.Title, postQuestionCommand.Problem, postQuestionCommand.Code, postQuestionCommand.Tag);

            //execute logic
            return result;
        }
    }
}