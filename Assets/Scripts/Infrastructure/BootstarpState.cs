using Input;
using Scripts;
using System;

namespace Assets.Scripts.Infrastructure
{
    public class BootstarpState : IState
    {
        private GameStateMachine _stateMachine;

        public BootstarpState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            RegisterServices();
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            Game.InputService = RegisterInputService();
        }

        private static IInputService RegisterInputService() =>
            new StandaloneInputService();
    }
}
