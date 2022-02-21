using UnityEngine;
using System;

namespace AI
{
    public interface IView
    {
        public Action lowDistanceAction { get; set; }
        public Components components { get; }
        public void Move(Vector3 direction);
    }
}