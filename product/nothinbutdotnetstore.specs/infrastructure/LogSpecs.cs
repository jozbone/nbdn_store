using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.logging;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class LogSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Log))]
        public class when_accessing_logging_functionality : concern
        {
            Establish c = () =>
            {
                container = an<DependencyContainer>();
                logger_factory = an<LoggerFactory>();
                the_actual_logger = an<Logger>();

                logger_factory.Stub(x => x.create_logger_bound_to(typeof(when_accessing_logging_functionality))).Return(
                    the_actual_logger);

                ContainerResolver resolver = () => container;
                change(() => Container.container_resolver).to(resolver);

                container.Stub(x => x.an<LoggerFactory>()).Return(logger_factory);
            };

            Because b = () =>
                result = Log.an;

            It should_return_a_logger_bound_to_the_calling_type = () =>
                result.ShouldEqual(the_actual_logger);

            static Logger result;
            static Logger the_actual_logger;
            static DependencyContainer container;
            static LoggerFactory logger_factory;
        }
    }
}