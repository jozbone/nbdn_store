using System.Web.UI;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public class DefaultViewFor<ViewModel> : Page, View<ViewModel>
    {
        public ViewModel model { get; set; }
    }
}