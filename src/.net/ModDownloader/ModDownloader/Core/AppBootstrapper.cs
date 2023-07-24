using Splat;

namespace ModDownloader.Core
{
    public class AppBootstrapper : IEnableLogger 
    {  
        public AppBootstrapper() 
        { 
            Locator.CurrentMutable.RegisterConstant(new FeedService(), typeof(IFeedService));
        }  
    } 
}
