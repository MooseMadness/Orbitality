using UnityEngine;
using System.Collections.Generic;

namespace Game.Orbits
{
    using GameLoop;

    public class OrbitsSystem : ITickable
    {
        private Vector2 _center;
        private SortedList<int, OrbitWalker> _walkers;

        public OrbitsSystem(Vector2 systemCenter)
        {
            _center = systemCenter;
            _walkers = new SortedList<int, OrbitWalker>();
        }

        public void Add(OrbitWalker orbitWalker)
        {
            _walkers.Add(orbitWalker.Id, orbitWalker);
        }

        public void Remove(int id)
        {
            _walkers.Remove(id);
        }

        public void Tick(float deltaTime)
        {
            foreach (var walker in _walkers.Values)
                UpdatePosition(walker, deltaTime);
        }

        private void UpdatePosition(OrbitWalker walker, float deltaTime)
        {
            walker.CurAngle += walker.AngularSpeed * deltaTime;
            var radians = walker.CurAngle * Mathf.Deg2Rad;

            Vector2 newPos = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
            newPos = newPos * walker.OrbitRadius + _center;

            var prevPos = walker.Transform.localPosition; 
            walker.Transform.localPosition = newPos;
            var moveDir = (walker.Transform.localPosition - prevPos).normalized;
            walker.Transform.localRotation = Quaternion.LookRotation(moveDir);
        }
    }
}