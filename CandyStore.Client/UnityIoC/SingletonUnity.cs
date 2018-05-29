using Unity;

namespace CandyStore.Client.UnityIoC
{
    public sealed class SingletonUnity
    {
        private static UnityContainer _unityContainer;

        private SingletonUnity()
        {

        }

        public static UnityContainer Instance
        {
            get
            {
                if (_unityContainer == null)
                {
                    _unityContainer = new UnityContainer();
                }

                return _unityContainer;
            }
        }
    }
}


