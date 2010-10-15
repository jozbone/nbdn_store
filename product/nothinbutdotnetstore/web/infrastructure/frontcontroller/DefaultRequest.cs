namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public class DefaultRequest : Request
    {
        Payload payload;
        InputModelMapper input_model_mapper;

        public DefaultRequest(Payload payload, InputModelMapper input_model_mapper)
        {
            this.payload = payload;
            this.input_model_mapper = input_model_mapper;
        }

        public InputModel map<InputModel>()
        {
            return input_model_mapper.map_from<InputModel>(payload);
        }
    }
}