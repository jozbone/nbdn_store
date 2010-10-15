using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;
using Rhino.Mocks;
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
                payloadMapper = an<OurInputPayloadMapper>();

            };

            Because b = () =>
                result = sut.map<OurInputModel>();

            It should_use_the_payload_mapper_to_map_the_payload_to_the_model = () =>
                payloadMapper.received(x => x.map_our_input_model_request_payload_to_our_input_model(payload, the_mapped_model));

            It should_return_the_model_mapped_from_the_request_payload = () =>
                result.ShouldEqual(the_mapped_model);
            

            static OurInputModel result;
            static OurInputModel the_mapped_model;
            static Payload payload;
            static OurInputPayloadMapper payloadMapper;
        }

        class OurInputPayloadMapper
        {
            public void map_our_input_model_request_payload_to_our_input_model(Payload payload, OurInputModel input_model)
            {
                throw new NotImplementedException();
            }
        }

         class OurInputModel
        {
        }
    }
}