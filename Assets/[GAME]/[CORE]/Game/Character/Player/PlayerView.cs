using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PLAYER
{
    public class PlayerView : MonoBehaviour, IView
    {
        [SerializeField] private Components components;

        Components IView.components { get { return components; } }

        public void Move(Vector3 direction)
        {
            components.controller.Move(direction * components.speed);
        }

        public void Rotate(Quaternion direction)
        {
            components.my_transform.rotation = Quaternion.Lerp(components.my_transform.rotation, direction, components.rotation_speed * 10 * Time.deltaTime);
        }
    }


    [System.Serializable]
    public struct Components
    {
        public Transform my_transform;
        public CharacterController controller;
        public float speed;
        public float rotation_speed;
        public Transform camera;
    }
}
