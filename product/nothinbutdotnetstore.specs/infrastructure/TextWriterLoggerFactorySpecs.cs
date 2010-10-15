 using System.IO;
 using System.Text;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.logging;
 using nothinbutdotnetstore.infrastructure.logging.basic;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class TextWriterLoggerFactorySpecs
     {
         public abstract class concern : Observes<LoggerFactory,
                                             TextWriterLoggerFactory>
         {
        
         }

         [Subject(typeof(TextWriterLoggerFactory))]
         public class when_creating_a_logger_bound_to_a_calling_type : concern
         {

             Establish c = () =>
             {
                 writer = new StringWriter(new StringBuilder());
                 provide_a_basic_sut_constructor_argument<TextWriter>(writer);
             };

             Because b = () =>
                 result = sut.create_logger_bound_to(typeof(int));

             It should_return_a_text_writer_logger = () =>
                 result.ShouldBeAn<TextWriterLogger>()
                     .writer.ShouldEqual(writer);


             static Logger result;
             static StringWriter writer;
         }
     }
 }
