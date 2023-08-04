using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.EnemyBot
{
    public class Enemy : MonoBehaviour
    {
        public void Damage()
        {
            gameObject.SetActive(false);
        }
    }
}
