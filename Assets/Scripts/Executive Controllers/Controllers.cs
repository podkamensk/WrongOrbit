using System.Collections.Generic;

namespace WrongOrbit
{
    internal sealed class Controllers : IInit, IExecute, ILateExecute, IFixedExecute, ICleanUp
    {
        private readonly List<IInit> _initControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ILateExecute> _lateControllers;
        private readonly List<IFixedExecute> _fixedControllers;
        private readonly List<ICleanUp> _cleanupControllers;

        internal Controllers()
        {
            _initControllers = new List<IInit>();
            _executeControllers = new List<IExecute>();
            _lateControllers = new List<ILateExecute>();
            _fixedControllers = new List<IFixedExecute>();
            _cleanupControllers = new List<ICleanUp>();
        }

        internal Controllers Add(IController controller)    //IController interface is needed to use all types of child interfaces as an argument
            //Categorizes the controller into Init, Exec, LateExec, FixedExec Destroy categories and adds them to revelant list<>
        {
            if (controller is IInit initializeController)
            {
                _initControllers.Add(initializeController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }

            if (controller is ILateExecute lateExecuteController)
            {
                _lateControllers.Add(lateExecuteController);
            }

            if (controller is IFixedExecute fixedExecuteController)
            {
                _fixedControllers.Add(fixedExecuteController);
            }

            if (controller is ICleanUp cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }

            return this;
        }

        public void Init()
        //Launches Init() in all Init controllers in the Init List 
        {
            for (var index = 0; index < _initControllers.Count; ++index)
            {
                _initControllers[index].Init();
            }
        }

        public void Execute(float deltaTime)
        //Launches Ecxecute() in all Ecxecute controllers in the Ecxecute List 
        {
            for (var index = 0; index < _executeControllers.Count; ++index)
            {
                _executeControllers[index].Execute(deltaTime);
            }
        }

        public void LateExecute(float deltaTime)
        //Launches LateEcxecute() in all LateEcxecute controllers in the LateEcxecute List 
        {
            for (var index = 0; index < _lateControllers.Count; ++index)
            {
                _lateControllers[index].LateExecute(deltaTime);
            }
        }

        public void FixedExecute(float fixedDeltaTime)
        //Launches FixedEcxecute() in all FixedEcxecute controllers in the FixedEcxecute List 
        {
            for (var index = 0; index < _fixedControllers.Count; ++index)
            {
                _fixedControllers[index].FixedExecute(fixedDeltaTime);
            }
        }

        public void CleanUp()
        //Launches CleanUp() in all CleanUp controllers in the CleanUp List 
        {
            for (var index = 0; index < _cleanupControllers.Count; ++index)
            {
                _cleanupControllers[index].CleanUp();
            }
        }
    }
}

