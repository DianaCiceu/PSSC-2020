using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    public struct PostQuestionCmd
    {
        [Required]
        public string Title { get; private set; }
		[Required]
		public string Problem { get; private set; }
		public string Code { get; set;}
		public string Tag { get; set;}
		
       

        public PostQuestionCmd(string title, string problem, string code, string tag)
        {
            Title = title;
            Problem = problem;
            Code = code;
            Tag = tag;
        }
    }
}