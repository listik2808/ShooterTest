using Assets.Scripts.Infrastructure;
using Input;
using UnityEngine;

namespace Scripts
{
    public class Game
    {
        public static IInputService InputService;
        public GameStateMachine StateMachina;

        public Game()
        {
            StateMachina = new GameStateMachine();
        }
    }
}