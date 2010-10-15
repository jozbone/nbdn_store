using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class DependencyContainerSpecs
    {
        public abstract class concern : Observes<DependencyContainer,
                                            DefaultDependencyContainer>
        {
        }

        [Subject(typeof(DefaultDependencyContainer))]
        public class when_getting_a_dependency_and_it_has_the_factory_for_that_dependency : concern
        {
            Establish c = () =>
            {
                dependencies = new Dictionary<DependencyType, DependencyFactory>();
                provide_a_basic_sut_constructor_argument(dependencies);
                dependency_type = an<DependencyType>();
                var dependency_factory = an<DependencyFactory>();

                the_connection = new SqlConnection();
                dependencies.Add(dependency_type, dependency_factory);

                dependency_type.Stub(x => x.represents(typeof(IDbConnection))).Return(true);
                dependency_factory.Stub(x => x.create()).Return(the_connection);
            };

            Because b = () =>
                result = sut.an<IDbConnection>();

            It should_return_the_dependency_created_by_the_factory = () =>
                result.ShouldEqual(the_connection);

            static IDbConnection result;
            static IDbConnection the_connection;
            static IDictionary<DependencyType, DependencyFactory> dependencies;
            static DependencyType dependency_type;
        }
    }
}