using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.tasks.startup;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;

namespace nothinbutdotnetstore.specs.tasks
{
    public class StartupSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Startup))]
        public class when_the_application_startup_process_has_finished : concern
        {
            Because b = () =>
                Startup.run();

            It should_be_able_to_access_key_application_services = () =>
            {
                Log.an.ShouldNotBeNull();
                Container.resolve.an<FrontController>().ShouldBeAn<DefaultFrontController>();
            };
        }
    }
}