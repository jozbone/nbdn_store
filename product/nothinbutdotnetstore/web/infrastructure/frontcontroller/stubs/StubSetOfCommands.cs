using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller.stubs
{
    public class StubSetOfCommands : IEnumerable<RequestCommand>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<RequestCommand> GetEnumerator()
        {
            throw new NotImplementedException();
            //            yield return new DefaultRequestCommand(request => true, new ViewMainDepartmentsInTheStore());
            //            yield return new DefaultRequestCommand(request => true, new ViewSubDepartmentsInTheStore());
            //            yield return new DefaultRequestCommand(request => true, new ViewProductsInDepartments());
        }
    }
}