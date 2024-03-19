using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityInAction
{    
    [RequireComponent(typeof(CharacterController))]
    [AddComponentMenu("Unity in Action/FPS Input")]
    public class FPSInput : MonoBehaviour
    {
        private CharacterController controller;
        public float speed = 6.0f;

        float gravity = -9.81f;
        // Start is called before the first frame update
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            // transform.Translate(0, speed, 0);
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;
            // transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);

            movement.y = gravity;

            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            controller.Move(movement);
        }
    }
}
