using System;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public class DefaultRequest : Request
    {
        Payload payload;

        public DefaultRequest(Payload payload)
        {
            this.payload = payload;
        }

        public InputModel map<InputModel>()
        {
            throw new NotImplementedException();
        }
    }
}