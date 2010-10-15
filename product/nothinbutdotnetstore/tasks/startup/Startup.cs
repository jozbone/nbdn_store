using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.basic;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;
using nothinbutdotnetstore.web.infrastructure.frontcontroller.stubs;
using nothinbutdotnetstore.web;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        public static void run()
        {
            var factories_and_dependencies = new Dictionary<Type, DependencyFactory>();
            factories_and_dependencies.Add(typeof(LoggerFactory),
                                           new BasicDependencyFactory(() => new TextWriterLoggerFactory(Console.Out)));
            List<RequestCommand> commands = new List<RequestCommand>();

            var stubCatalogTasks = new StubCatalogTasks();
            var responseEngine = new BasicResponseEngine();

            commands.Add(new DefaultRequestCommand(x => true, new ViewMainDepartmentsInTheStore(stubCatalogTasks, responseEngine)));
            commands.Add(new DefaultRequestCommand(x => true, new ViewSubDepartmentsInTheStore(stubCatalogTasks, responseEngine)));
            commands.Add(new DefaultRequestCommand(x => true, new ViewProductsInDepartments(stubCatalogTasks, responseEngine)));

            factories_and_dependencies.Add(typeof(RequestFactory), new BasicDependencyFactory(() => new StubRequestFactory()));
            factories_and_dependencies.Add(typeof(FrontController),
                                           new BasicDependencyFactory(() => new DefaultFrontController(new DefaultCommandRegistry(commands))));

            Container.container_resolver = () => new DefaultDependencyContainer(new DefaultDependencyFactoryRegistry(factories_and_dependencies));

        }
    }
}