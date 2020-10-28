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
		public string Text { get; private set; }
	
		public string[] Tag { get; set;}

        public PostQuestionCmd(string title, string text, string[] tag)
        {
            Title = title;
            Text = text;
            Tag = tag;
        }
    }
}