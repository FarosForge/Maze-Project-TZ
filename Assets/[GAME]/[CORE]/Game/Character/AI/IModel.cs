using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public interface IModel
    {
        public bool followTarget { get; set; }

        public Vector3 moveDirection(Components components);

        public bool CheckDistanceToTarget(Components components);
    }
}
