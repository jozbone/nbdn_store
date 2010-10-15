 using System.Data;
 using System.IO;
 using System.Text;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.logging;
 using nothinbutdotnetstore.infrastructure.logging.basic;
 using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class TextWriterLoggerSpecs
     {
         public abstract class concern : Observes<Logger,
                                             TextWriterLogger>
         {
        
         }

         [Subject(typeof(TextWriterLogger))]
         public class when_logging_an_informational_message : concern
         {
             const string message = "this is the message";

             Establish c = () =>
             {
                 backing_store = new StringBuilder();
                 provide_a_basic_sut_constructor_argument<TextWriter>(new StringWriter(backing_store));
             };

             Because b = () =>
                 sut.informational(message);


             It should_write_the_line_of_detail_to_the_backing_writer = () =>
                 backing_store.ToString().ShouldBeEqualIgnoringCase("{0}\r\n".format_using(message));

             static StringBuilder backing_store;
                 
         }
     }
 }
