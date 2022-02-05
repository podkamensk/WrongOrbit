using UnityEngine;

namespace WrongOrbit
{
    public class GameMaster : MonoBehaviour
    {
        [SerializeField] private Settings _allSettings;

        private Controllers _allControllers;

        private void Start()
        {
            DontDestroyOnLoad(this);

            _allControllers = new Controllers();
            new GameInitialize(_allControllers, _allSettings);

            _allControllers.Init();
        }

        private void Update()
        {
            _allControllers.Execute(Time.deltaTime);
        }
        private void LateUpdate()
        {
            _allControllers.LateExecute(Time.deltaTime);
        }
        private void FixedUpdate()
        {
            _allControllers.FixedExecute(Time.fixedDeltaTime);
        }
        private void OnDestroy()
        {
            _allControllers.CleanUp();
        }
    }
}
