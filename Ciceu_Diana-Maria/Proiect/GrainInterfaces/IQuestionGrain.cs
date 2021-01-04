using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StackUnderflow.EF.Models;

namespace GrainInterfaces
{
    public interface IQuestionGrain : IGrainWithStringKey
    {
        Task<IEnumerable<Post>> GetQuestionsAsync();
    }
}