using System;
using System.Collections.Generic;
using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utilities;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ResponseEngineSpecs
    {
        public abstract class concern : Observes<ResponseEngine,
                                            BasicResponseEngine>
        {
            protected static IEnumerable<string> view_model;

            Establish c = () => { };
        }

        [Subject(typeof(BasicResponseEngine))]
        public class when_displaying_a_view_model : concern
        {
            Establish c = () =>
            {
                view_registry = the_dependency<ViewPathRegistry>();
                path = "blah.aspx";
                details = new PageCreationDetails {path = path, type = typeof(View<IEnumerable<string>>)};
                view = an<View<IEnumerable<string>>>();
                view_registry.Stub(x => x.get_path_to_view_for<IEnumerable<string>>()).Return(path);
                the_context = ObjectMother.create_http_context();

                provide_a_basic_sut_constructor_argument<PageFactory>((x,y) =>
                {
                    the_requested_details = new PageCreationDetails {path = x, type = y};
                    return view;
                });
                provide_a_basic_sut_constructor_argument<ContextResolver>(() => the_context);
            };

            Because b = () =>
                sut.display(view_model);

            It should_create_the_view_using_the_factory = () =>
            {
                details.Equals(the_requested_details).ShouldBeTrue();
                view.model.ShouldEqual(view_model);
            };

            It should_tell_the_view_to_process_itself = () =>
                view.received(x => x.ProcessRequest(the_context));

            static ViewPathRegistry view_registry;
            static View<IEnumerable<string>> view;
            static PageFactory page_factory;
            static string path;
            static HttpContext the_context;
            static PageCreationDetails details;
            static PageCreationDetails the_requested_details;
        }

        public class PageCreationDetails : IEquatable<PageCreationDetails>
        {
            public string path { get; set; }
            public Type type { get; set; }

            public bool Equals(PageCreationDetails other)
            {
                return this.path == other.path &&
                    this.type == other.type;
            }
        }
    }
}