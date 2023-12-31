﻿using Assets.Scripts.Infrastructure;
using UnityEngine;

namespace Scripts
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();
            _game.StateMachina.Enter<BootstarpState>();
        }
    }
}