﻿using System.Threading.Tasks;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Common.Commands
{
    public class ExecutableCommand<TResponse> : Command where TResponse: ICommandResponse, new()
    {
        public ExecutableCommand(string commandName) : base(commandName)
        {

        }

        public TResponse Execute(ICommandExecutor executor)
        {
           return GetResponseFromResponseText(executor.Execute(this)); 
        }

        public async Task<TResponse> ExecuteAsync(ICommandExecutor executor)
        {
            return GetResponseFromResponseText(await executor.ExecuteAsync(this).ConfigureAwait(false));
        }

        protected TResponse GetResponseFromResponseText(string responseText)
        {
            TResponse response = CreateResponse();

            BeforApplyResponseText(response, responseText);
            response.ApplyResponseText(responseText);

            return response;
        }

        protected virtual TResponse CreateResponse()
        {
            return new TResponse();
        }

        protected virtual void BeforApplyResponseText(TResponse response, string responseText)
        {
            
        }
    }
}