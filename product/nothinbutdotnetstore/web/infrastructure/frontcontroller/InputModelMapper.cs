namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public interface InputModelMapper
    {
        InputModel map_from<InputModel>(Payload payload);
    }
}