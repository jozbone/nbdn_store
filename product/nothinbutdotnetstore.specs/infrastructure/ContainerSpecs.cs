using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class ContainerSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Container))]
        public class when_requesting_container_servcies : concern
        {
            Establish c = () =>
            {
                the_underlying_container = an<DependencyContainer>();
                ContainerResolver resolver = () => the_underlying_container;
                change(() => Container.container_resolver).to(resolver);
            };

            Because b = () =>
                result = Container.resolve;

            It should_return_the_gateway_to_the_actual_container = () =>
                result.ShouldEqual(the_underlying_container);

            static DependencyContainer result;
            static DependencyContainer the_underlying_container;
        }
    }
}