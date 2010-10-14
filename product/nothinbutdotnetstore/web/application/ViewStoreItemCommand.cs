using System;
using System.Collections.Generic;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;

namespace nothinbutdotnetstore.web.application
{
    public class ViewStoreItemCommand<TaskType, ItemType> : ApplicationCommand
    {
        Func<TaskType, ItemType> action;
        readonly ResponseEngine response_engine;

        public ViewStoreItemCommand(Func<TaskType, ItemType> action, ResponseEngine response_engine)
        {
            this.action = action;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display((action));
        }
    }

}