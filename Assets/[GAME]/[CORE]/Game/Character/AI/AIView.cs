using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

namespace AI
{
    public class AIView : MonoBehaviour, IView
    {
        [SerializeField] private Components components;

        public Action lowDistanceAction { get; set; }

        Components IView.components { get { return components; } }

        public void Move(Vector3 direction)
        {
            components.agent.SetDestination(direction);
        }
    }

    [System.Serializable]
    public struct Components
    {
        public AIType type;
        public NavMeshAgent agent;
        public Transform[] path_points;
        public RayScan rayScan;
        public Transform my_transform;
    }

    public enum AIType
    {
        Enemy,
        Friendly
    }
}