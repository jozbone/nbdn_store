namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public interface ViewPathRegistry
    {
        string get_path_to_view_for<ViewModel>();
    }
}