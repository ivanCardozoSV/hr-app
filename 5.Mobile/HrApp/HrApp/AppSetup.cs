using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using HrApp.Services;
using HrApp.Services.Interfaces;
using HrApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp
{
    public sealed class AppSetup
    {
        public static void Initialize()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<LoginViewModel>().AsSelf();
            builder.RegisterType<CandidateViewModel>().AsSelf();
            builder.RegisterType<CandidateService>().As<ICandidateService>();

            IContainer container = builder.Build();

            AutofacServiceLocator asl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => asl);
        }
    }
}
