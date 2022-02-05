

namespace WrongOrbit
{
    public interface ICleanUp : IController
    //Interface for CleanUp method should be done in the mastercontrollers OnDestroy()
    {
        void CleanUp();

    }
}