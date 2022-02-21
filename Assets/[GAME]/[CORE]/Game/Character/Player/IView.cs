using UnityEngine;

namespace PLAYER
{
    public interface IView
    {
        public Components components { get; }
        public void Move(Vector3 direction);
        public void Rotate(Quaternion direction);
    }
}
