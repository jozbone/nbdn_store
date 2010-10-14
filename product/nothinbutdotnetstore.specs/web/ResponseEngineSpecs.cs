 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino; 
 using nothinbutdotnetstore.web.infrastructure.frontcontroller;
 
namespace nothinbutdotnetstore.specs.web
{   
    public class ResponseEngineSpecs
    {
        public abstract class concern : Observes<ResponseEngine,
                                            BasicResponseEngine>
        {
            protected static IEnumerable<string> data;
            protected static View view;

            Establish c = () =>
            {
                data = an<IEnumerable<string>>();
                view = an<View>();


            };
        }

        [Subject(typeof(BasicResponseEngine))]
        public class when_displaying_a_view_model : concern
        {
            Because b = () =>
                sut.display(data);

            It should_pass_the_model_data_to_the_view = () =>
                view.received(x => x.Apply(data));


        }
    }
}
