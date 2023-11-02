using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Wemail.schedule.Views;

namespace Wemail.schedule
{
    [Module(ModuleName = "Schedule")]
    public class scheduleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager=containerProvider.Resolve<IRegionManager>();
           
            var contentRegion = regionManager.Regions["ContentRegion"];
            contentRegion.RequestNavigate(nameof(ScheduleView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ScheduleView>();
        }
    }
}