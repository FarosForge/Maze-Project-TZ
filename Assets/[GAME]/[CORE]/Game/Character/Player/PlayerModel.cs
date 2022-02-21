using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PLAYER
{
    public class PlayerModel : IModel
    {
        private Vector3 direction;
        private Vector3 storeDir;
        private Vector3 directionForward;
        private Vector3 dirSides;

        private Vector2 InputDirection
        {
            get { return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); }
        }

        public Vector3 moveDirection(Transform camera)
        {
            storeDir = camera.right;

            directionForward = storeDir * InputDirection.x;
            dirSides = camera.forward * InputDirection.y;

            return (directionForward + dirSides).normalized * Time.deltaTime;
        }

        public Quaternion RotatePlayer(Transform my_transform, Transform camera)
        {
            Quaternion rot = my_transform.rotation;

            storeDir = camera.right;
            direction = my_transform.localPosition + (storeDir * InputDirection.x) + (camera.forward * InputDirection.y);

            Vector3 dir = direction - my_transform.localPosition;
            dir.y = 0;

            float angle = Vector3.Angle(my_transform.forward, dir);

            if (Velocity())
            {
                if (angle != 0)
                {
                    rot = Quaternion.LookRotation(dir);
                }
            }

            return rot;
        }

        bool Velocity()
        {
            if (InputDirection.x != 0 || InputDirection.y != 0)
            {
                return true;
            }

            return false;
        }
    }
}