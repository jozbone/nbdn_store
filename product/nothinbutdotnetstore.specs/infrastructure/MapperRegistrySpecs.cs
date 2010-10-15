 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.infrastructure.containers;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class MapperRegistrySpecs
     {
         public abstract class concern : Observes<MapperRegistry,
                                             DefaultMapperRegistry>
         {
        
         }

         [Subject(typeof(DefaultMapperRegistry))]
         public class when_retrieving_a_mapper_to_map_a_specific_input_output_pair : concern
         {

             Establish c = () =>
             {
                 the_mapper = an<Mapper<int, string>>();
                 container = the_dependency<DependencyContainer>();

                 container.Stub(x => x.an<Mapper<int, string>>()).Return(the_mapper);
             };

             Because b = () =>
                 result = sut.get_mapper_to_map<int, string>();


             It should_return_the_appropriate_mapper_resolved_by_the_container = () =>
                 result.ShouldEqual(the_mapper);

             static Mapper<int,string> result;
             static Mapper<int, string> the_mapper;
             static DependencyContainer container;
         }
     }
 }
