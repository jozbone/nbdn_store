using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class DependancyContainerSpecs
    {
        public abstract class concern : Observes
        {}

        [Subject(typeof(DependencyContainer))]
        public class when_resolving_a_specific_dependancy : concern
        {
            Establish c = () =>
            {
                the_underlying_container = an<DependencyContainer>();
                ContainerResolver resolver = () => the_underlying_container;
                change(() => Container.container_resolver).to(resolver);
                concrete_Dependancy = new concreteDependancy();
            };

            Because b = () =>
                result = Container.resolve.an<stubDependency>();


            It should_find_the_requested_type_of_dependancy = () =>
            {
                result.ShouldEqual(concrete_Dependancy);
            };

            static stubDependency result;
            static DependencyContainer the_underlying_container;
            static concreteDependancy concrete_Dependancy;
        }

        
        public interface stubDependency
        {
            
        }
        public class concreteDependancy : stubDependency
        {}
    }
}