using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _state;
        private IState _activeState;
        public GameStateMachine() 
        {
            _state = new Dictionary<Type, IState>
            {
                [typeof(BootstarpState)] = new BootstarpState(this),
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState state = _state[typeof(TState)];
            _activeState = state;
            state.Enter();
        }
    }
}
