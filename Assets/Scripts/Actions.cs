using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actions
{
    public class FireCommand: ICommand
    {
        public void Execute(ref Player _player)
        {
            if (_player == null) return;

            _player.Attack();
        }
    }
}
