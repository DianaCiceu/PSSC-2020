using System;

namespace Tema6_18
{
    class Program
    {
        static void Main(string[] args)
        {

            var wf = from createReplyResult in BoundedContextDSL.ValidateReply(100, 1, "testaslkdhfkjsdfhgdkjfghjdfkgh")
                let validReply = (CreateReplyResult.ReplyValid)createReplyResult
                from checkLanguageResult in BoundedContextDSL.CheckLanguage(validReply.Reply.Answer)
                from ownerAck in BoundedContextDSL.SendAckToOwner(checkLanguageResult)
                from authorAck in BoundedContextDSL.SendAckToAuthor(checkLanguageResult)
                select (validReply, checkLanguageResult, ownerAck, authorAck);
            Console.WriteLine("Hello World!");
        }
    }
}
