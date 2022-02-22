using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI
{
    public class AIModel : IModel
    {
        int path_ID = 0;

        private RayScan rayScan;

        public AIModel(Transform transform, Transform target)
        {
            rayScan = new RayScan(transform, target);
        }

        public bool followTarget { get; set; }

        public bool CheckDistanceToTarget(Components components)
        {
            if(rayScan.CheckViewSpace())
            {
                if(Vector3.Distance(components.my_transform.position, rayScan.target.position) <= components.agent.stoppingDistance)
                {
                    return true;
                }
            }

            return false;
        }

        public Vector3 moveDirection(Components components)
        {
            if (!followTarget)
            {
                if (!rayScan.CheckViewSpace())
                {
                    if (Vector3.Distance(components.my_transform.position, components.path_points[path_ID].position) <= components.agent.stoppingDistance)
                    {
                        SetNewPoint(components.path_points.Length);
                    }
                    else
                    {
                        return components.path_points[path_ID].position;
                    }
                }
            }

            return rayScan.target.position;
        }

        void SetNewPoint(int length)
        {
            path_ID++;

            if(path_ID >= length)
            {
                path_ID = 0;
            }
        }
    }
}