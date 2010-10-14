using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.web.infrastructure.frontcontroller.stubs;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public class BasicResponseEngine : ResponseEngine
    {
        ViewPathRegistry view_path_registry;
        PageFactory page_factory;
        ContextResolver context_resolver;

        public BasicResponseEngine(ViewPathRegistry view_path_registry, PageFactory page_factory,
                                   ContextResolver context_resolver)
        {
            this.view_path_registry = view_path_registry;
            this.page_factory = page_factory;
            this.context_resolver = context_resolver;
        }

        public BasicResponseEngine():this(new StubViewPathRegistry(),BuildManager.CreateInstanceFromVirtualPath,
            () => HttpContext.Current)
        {
        }

        public void display<ViewModel>(ViewModel view_model)
        {
            var view =
                (View<ViewModel>)
                    page_factory(view_path_registry.get_path_to_view_for<ViewModel>(), typeof(View<ViewModel>));
            view.model = view_model;
            view.ProcessRequest(context_resolver());
        }
    }
}