using UnityEngine;
using System.Collections.Generic;

namespace Game.Fire
{
    [CreateAssetMenu(fileName = "Rockets", menuName = "Configs/Game/Rockets")]
    public class RocketsStorage : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] RocketProvider[] _rocketsPrefabs;

        private SortedDictionary<RocketType, RocketProvider> _rocketsDict;

        public RocketProvider GetRocketPrefab(RocketType rocketType)
        {
            return _rocketsDict[rocketType];
        }
            
        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            _rocketsDict = new SortedDictionary<RocketType, RocketProvider>();
            foreach (var rocketPrefab in _rocketsPrefabs)
                _rocketsDict.Add(rocketPrefab.RocketType, rocketPrefab);
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize() { }
    }
}