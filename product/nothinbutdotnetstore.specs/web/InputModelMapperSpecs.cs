using System.Collections.Specialized;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class InputModelMapperSpecs
    {
        public abstract class concern : Observes<InputModelMapper,
                                            DefaultInputModelMapper>
        {
        }

        [Subject(typeof(DefaultInputModelMapper))]
        public class when_mapping_an_input_model : concern
        {
            Establish c = () =>
            {
                payload = an<Payload>();
                mapper = an<Mapper<NameValueCollection, OurModel>>();
                raw_details = new NameValueCollection();
                payload.Stub(x => x.raw_values).Return(raw_details);
                the_mapped_model = new OurModel();

                mapper_registry = the_dependency<MapperRegistry>();
                mapper_registry.Stub(x => x.get_mapper_to_map<NameValueCollection, OurModel>()).Return(mapper);
                mapper.Stub(mapper1 => mapper1.map_from(raw_details)).Return(the_mapped_model);
            };

            Because b = () =>
                result = sut.map_from<OurModel>(payload);

            It should_return_the_model_mapped_from_the_raw_information = () =>
                result.ShouldEqual(the_mapped_model);

            static OurModel result;
            static OurModel the_mapped_model;
            static NameValueCollection raw_details;
            static Payload payload;
            static MapperRegistry mapper_registry;
            static Mapper<NameValueCollection, OurModel> mapper;
        }

        public class OurModel
        {
        }
    }
}