using System;
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
            Establish c = () => { dependencies = the_dependency<DependencyFactoryRegistry>(); };

            protected static DependencyFactoryRegistry dependencies;
        }

        [Subject(typeof(DefaultDependencyContainer))]
        public class when_getting_a_dependency_and_it_has_the_factory_for_that_dependency : concern
        {
            Establish c = () =>
            {
                var dependency_factory = an<DependencyFactory>();

                the_connection = new SqlConnection();

                dependencies.Stub(x => x.get_dependency_factory_for(typeof(IDbConnection))).Return(dependency_factory);
                dependency_factory.Stub(x => x.create()).Return(the_connection);
            };

            Because b = () =>
                result = sut.an<IDbConnection>();

            It should_return_the_dependency_created_by_the_factory = () =>
                result.ShouldEqual(the_connection);

            static IDbConnection result;
            static IDbConnection the_connection;
        }

        [Subject(typeof(DefaultDependencyContainer))]
        public class when_attempting_to_get_a_dependency_and_the_factory_for_that_dependency_throws_an_exception :
            concern
        {
            Establish c = () =>
            {
                var dependency_factory = an<DependencyFactory>();
                inner_exception = new Exception();

                dependencies.Stub(x => x.get_dependency_factory_for(typeof(IDbConnection))).Return(dependency_factory);
                dependency_factory.Stub(x => x.create()).Throw(inner_exception);
            };

            Because b = () =>
                catch_exception(() => sut.an<IDbConnection>());

            It should_throw_a_dependency_creation_exception_with_the_appropriate_information = () =>
            {
                var exception = exception_thrown_by_the_sut.ShouldBeAn<DependencyCreationException>();
                exception.type_that_could_not_be_created.ShouldEqual(typeof(IDbConnection));
                exception.InnerException.ShouldEqual(inner_exception);
            };

            static Exception inner_exception;
        }
    }
}