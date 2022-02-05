
namespace WrongOrbit
{
    public interface IExecute : IController
        //Interface for Execute method should be done in the mastercontrollers Update()
    {
        void Execute(float deltaTime);
    }
}