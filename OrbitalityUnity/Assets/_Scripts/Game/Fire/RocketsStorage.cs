using UnityEngine;
using System.Collections.Generic;

namespace Game.Fire
{
    [CreateAssetMenu(fileName = "Rockets", menuName = "Configs/Game/Rockets")]
    public class RocketsStorage : ScriptableObject
    {
        [SerializeField] RocketProvider[] _rocketsPrefabs;

        public RocketProvider GetRocketPrefab(RocketType rocketType)
        {
            for(int i = 0; i < _rocketsPrefabs.Length; i++)
            {
                if (_rocketsPrefabs[i].RocketType == rocketType)
                    return _rocketsPrefabs[i];
            }

            return null;
        }
    }
}