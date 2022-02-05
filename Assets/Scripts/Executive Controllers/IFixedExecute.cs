
namespace WrongOrbit
{
    public interface IFixedExecute : IController
    //Interface for FixedExecute method should be done in the mastercontrollers FixedUpdate()
    {
        void FixedExecute(float fixedDeltaTime);
    }
}