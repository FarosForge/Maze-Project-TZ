using UnityEngine;

namespace PLAYER
{
    public interface IModel
    {
        public Vector3 moveDirection(Transform camera);
        public Quaternion RotatePlayer(Transform my_transform, Transform camera);
    }
}