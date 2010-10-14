using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;

namespace nothinbutdotnetstore.specs.web
{
    public class RequestSpecs
    {
        public abstract class concern : Observes<Request,
                                            DefaultRequest>
        {
        }

        [Subject(typeof(DefaultRequest))]
        public class when_mapping_an_input_model : concern
        {
            Establish c = () =>
            {
                the_mapped_model = new OurInputModel();
                payload = the_dependency<Payload>();

            };

            Because b = () =>
                result = sut.map<OurInputModel>();

            It should_return_the_model_mapped_from_the_request_payload = () =>
                result.ShouldEqual(the_mapped_model);

            static OurInputModel result;
            static OurInputModel the_mapped_model;
            static Payload payload;
        }

        class OurInputModel
        {
        }
    }
}