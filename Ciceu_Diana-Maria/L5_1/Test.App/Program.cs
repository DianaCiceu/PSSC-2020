using LanguageExt;
using LanguageExt.Common;
using Question.Domain.CreateQuestionWorkflow;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using static Question.Domain.CreateQuestionWorkflow.PostQuestionResult;
using static Question.Domain.CreateQuestionWorkflow.Question;

namespace Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tags = {"C#"};
            var question = UnverifiedQuestion.Create("Problem with homework ", "The type or namespace 'Result<>' could not be found",tags);
           // var textResult = UnverifiedText.Create("La crearea unei clase in C# tot apare aceeasi eroare.");

            question.Match(
                    Succ: question =>
                    { 
                        Console.WriteLine("Question is valid.");
                        return Unit.Default;
                    },
                    Fail: ex =>
                    {
                        Console.WriteLine($"Invalid question. Reason: {ex.Message}");
                        return Unit.Default;
                    }
                );


            Console.ReadLine();
        }

 
    }
}