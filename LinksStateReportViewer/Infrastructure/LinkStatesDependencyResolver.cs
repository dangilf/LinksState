using LinksState.BLL.Interfaces;
using LinksState.BLL.Services;
using LinksState.DAL.EF;
using LinksState.DAL.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinksStateReportViewer.Infrastructure
{
    public class LinkStatesDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;
        public LinkStatesDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<ICheckRequestService>().To<CheckRequestsService>();
            kernel.Bind<ILinkStatesService>().To<LinkStatesService>();
        }
    }
}