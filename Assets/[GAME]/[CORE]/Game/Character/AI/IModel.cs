using System;
using UnityEngine;

namespace AI
{
    public interface IModel
    {
        public Action<float> checkDistance { get; set; }
        public bool followTarget { get; set; }

        public Vector3 moveDirection(Components components);

        public bool CheckDistanceToTarget(Components components);
    }
}
