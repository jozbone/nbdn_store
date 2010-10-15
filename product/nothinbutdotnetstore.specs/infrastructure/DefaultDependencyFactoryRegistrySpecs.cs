 using System;
 using System.Collections.Generic;
 using System.Data;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers;
 using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class DefaultDependencyFactoryRegistrySpecs
     {
         public abstract class concern : Observes<DependencyFactoryRegistry,
                                             DefaultDependencyFactoryRegistry>
         {
        
         }

         [Subject(typeof(DefaultDependencyFactoryRegistry))]
         public class when_getting_the_dependency_factory_for_a_specific_type : concern
         {
             Establish c = () =>
             {
                 the_factory = an<DependencyFactory>();

                 dependency_factories = new Dictionary<Type,DependencyFactory>();

                 dependency_factories.Add(typeof(IDbConnection),the_factory);

                 provide_a_basic_sut_constructor_argument(dependency_factories);
             };

             Because b = () =>
                 result = sut.get_dependency_factory_for(typeof(IDbConnection));



             It should_return_the_factory_that_was_registered_for_the_type = () =>
                 result.ShouldEqual(the_factory);

             static DependencyFactory result;
             static DependencyFactory the_factory;
             static IDictionary<Type, DependencyFactory> dependency_factories;
         }

         [Subject(typeof(DefaultDependencyFactoryRegistry))]
         public class when_requesting_a_dependency_factory_for_an_unmapped_specific_type : concern
         {
             Establish c = () =>
             {
                 the_factory = an<DependencyFactory>();
                 dependency_factories = new Dictionary<Type, DependencyFactory>();
                 provide_a_basic_sut_constructor_argument(dependency_factories);
             };

             Because b = () =>
                 catch_exception(() => sut.get_dependency_factory_for(typeof(IDbConnection)));

             It should_throw_a_dependency_creation_exception_with_the_appropriate_information = () =>
             {
                 var exception = exception_thrown_by_the_sut.ShouldBeAn<DependencyCreationException>();
                 exception.type_that_could_not_be_created.ShouldEqual(typeof(IDbConnection));
                 exception.InnerException.ShouldEqual(null);
             };

             static DependencyFactory result;
             static DependencyFactory the_factory;
             static IDictionary<Type, DependencyFactory> dependency_factories;
         }
     }
 }
