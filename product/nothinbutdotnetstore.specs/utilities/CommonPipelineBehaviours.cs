using Machine.Specifications.DevelopWithPassion;
using nothinbutdotnetstore.infrastructure.containers;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.utilities {
    public class CommonPipelineBehaviours {
        static DependencyContainer dependency_container;

        public PipelineBehaviour create_to_provide_a_container_value_of<DependencyType>(DependencyType instance) {
            ContainerResolver resolver = () => dependency_container;
            dependency_container.Stub(x => x.an<DependencyType>()).Return(instance);

            var inner = new PipelineBehaviour(() => Container.container_resolver = resolver,
                                              () => Container.container_resolver = null);

            return new PipelineBehaviour(() => inner.start(),
                                         () =>
                                         {
                                             dependency_container = null;
                                             inner.finish();
                                         });
        }
    }
}