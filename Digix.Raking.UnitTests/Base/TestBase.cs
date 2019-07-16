using Autofac;
using Digix.Raking.Adapters;
using Digix.Raking.Domain.Core.Adapters;
using Digix.Raking.Domain.Core.DomainEvents;
using Digix.Raking.Domain.Core.Entities.Base;
using Digix.Raking.Domain.Core.Factories;
using Digix.Raking.Domain.Core.Services;
using Digix.Raking.Domain.Services.Factories;
using Digix.Raking.EventDispatcher;
using System.Reflection;

namespace Digix.Raking.Tests.Base
{
    public class TestBase
    {
        private IContainer _autofacContainer;
        protected IContainer AutofacContainer
        {
            get
            {
                if (_autofacContainer == null)
                {
                    var builder = new ContainerBuilder();

                    builder.RegisterAssemblyTypes(GetAssemblies()).AsImplementedInterfaces();

                    var container = builder.Build();

                    _autofacContainer = container;
                }

                return _autofacContainer;
            }
        }

        protected IRankingFamilyManager RankingFamilyManager
        {
            get
            {
                return AutofacContainer.Resolve<IRankingFamilyManager>();
            }
        }

        protected IScoreFamilyServiceManager ScoreFamilyServiceManager
        {
            get
            {
                return AutofacContainer.Resolve<IScoreFamilyServiceManager>();
            }
        }

        protected ICacheAdapter DistributedCacheAdapter
        {
            get
            {
                return AutofacContainer.Resolve<ICacheAdapter>();
            }
        }

        protected IAttendedFamiliesAdapter AttendedFamiliesAdapter
        {
            get
            {
                return AutofacContainer.Resolve<IAttendedFamiliesAdapter>();
            }
        }

        protected IDomainEventDispatcher DomainEventDispatcher
        {
            get
            {
                return AutofacContainer.Resolve<IDomainEventDispatcher>();
            }
        }

        protected IScoreFactory ScoreFactory
        {
            get
            {
                return AutofacContainer.Resolve<IScoreFactory>();
            }
        }

        private static Assembly[] GetAssemblies()
        {
            //return AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("Digix.Raking")).ToArray();//TODO: change to parameter

            return new Assembly[] {
            // TODO: Add Registry Classes to eliminate reference to Infrastructure
            Assembly.GetExecutingAssembly(),
            Assembly.GetAssembly(typeof(DomainEvent)),
            Assembly.GetAssembly(typeof(ScoreFactory)),
            Assembly.GetAssembly(typeof(BaseDomainEventHandler)),
            Assembly.GetAssembly(typeof(AttendedFamiliesAdapter)),
            Assembly.GetAssembly(typeof(DistributedCacheAdapter))
            }; // TODO: Move to Infrastucture Registry }
        }
    }
}
