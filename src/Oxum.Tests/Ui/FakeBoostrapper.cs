using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oxum.Ui;
using Raven.Client;

namespace Oxum.Tests.Ui
{
    public class FakeBoostrapper : Bootstrapper
    {
        public Func<IDocumentSession> DocumentSession { get; set; }

        protected override void ConfigureApplicationContainer(Ninject.IKernel container)
        {
            container.Bind<IDocumentSession>().ToMethod(c => DocumentSession.Invoke());
        }
    }
}
