using System;
using System.Data;
using System.Data.SqlClient;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class BasicDependencyFactorySpecs
    {
        public abstract class concern : Observes<DependencyFactory,
                                            BasicDependencyFactory>
        {
        }

        [Subject(typeof(BasicDependencyFactory))]
        public class when_creating_an_instance_of_a_dependency : concern
        {
            Establish c = () =>
            {
                the_connection = new SqlConnection();
                provide_a_basic_sut_constructor_argument<Func<object>>(() => the_connection);
            };

            Because b = () =>
                result = sut.create();

            It should_return_the_dependency_created_using_the_provided_factory = () =>
                result.ShouldEqual(the_connection);

            static object result;
            static IDbConnection the_connection;
        }
    }
}