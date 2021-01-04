using Orleans;
using Orleans.Streams;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GrainImplementation
{
    class public QuestionGrain: Orleans.Grain, IQuestionGrain, IAsyncObserver<Post>
    {
        private  StackUnderflowContext _dbContext;
        private QuestionGrain state;

        public QuestionGrain(StackUnderflowContext dbContext)
        {
            _dbContext = dbContext;
        }
		
		public async Task<IEnumerable<Post>> GetQuestionAsync()
        {
            return this;
        }
		
        public override async Task OnActivateAsync()
        {
            var key = this.GetPrimaryKey();
            Post post = new Post();

            var expPostId = from postId in post.PostId.ToString()
                      where postId.Equals(key.ToString())
                      select postId;

            var expParentPostId = from parentPostId in post.ParentPostId.ToString()
                            where parentPostId.Equals(key.ToString())
                            select parentPostId;


            // subscribe to replys stream
            var streamProvider = GetStreamProvider("SMSProvider");
            var stream = streamProvider.GetStream<string>(Guid.Empty, "questions");
            await stream.SubscribeAsync((IAsyncObserver<string>)this);
            
           
        }
		
		public Task OnCompletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task OnErrorAsync(Exception ex)
        {
            throw new NotImplementedException();
        }

       
    }
}