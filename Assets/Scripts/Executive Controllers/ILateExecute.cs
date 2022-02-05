
namespace WrongOrbit
{
    public interface ILateExecute : IController
    //Interface for LateExecute method should be done in the mastercontrollers LateUpdate()
    {
        void LateExecute(float deltaTime);
    }
}