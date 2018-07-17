using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace CandyStore.Client.Util
{
    public class SimpleInjectorContainer
    {
        private static Container _container;

        private SimpleInjectorContainer()
        {

        }

        public static Container Instance
        {
            get
            {
                if (_container == null)
                {
                    _container = new Container();
                    _container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
                }

                return _container;
            }
        }
    }
}
