﻿using UnityEngine;

namespace Game.Fire
{
    public class RocketProvider : MonoBehaviour
    {
        public RocketType RocketType;
        [SerializeField] Rigidbody _rb;
        [SerializeField] float _acceleration;

        public Rocket GetRocket()
        {
            return new Rocket {
                Rb = _rb,
                Acceleration = _acceleration
            };
        }
    }
}