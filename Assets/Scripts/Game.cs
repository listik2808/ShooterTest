using Input;
using UnityEngine;

namespace Scripts
{
    public class Game
    {
        public static IInputService InputService;

        public Game()
        {
            RegisterInputService();
        }

        private static void RegisterInputService()
        {
            InputService = new StandaloneInputService();
        }
    }
}