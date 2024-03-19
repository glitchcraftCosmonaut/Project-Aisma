using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityInAction
{
    public class MouseLook : MonoBehaviour
    {
        public enum RotationAxes
        {
            MouseXAndY = 0,
            MouseX = 1,
            MouseY = 2
        }
        public RotationAxes axes = RotationAxes.MouseXAndY;
        public float sensitivityX = 9.0f;
        public float sensitivityY = 9.0f;

        //limit the vertical rotation
        public float minimumY = -45.0f;
        public float maximumY = 45.0f;

        private float verticalRot = 0.0f;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(axes == RotationAxes.MouseX)
            {
                //horizontal rotation
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);

            }
            else if(axes == RotationAxes.MouseY)
            {
                //vertical rotation
                verticalRot -= Input.GetAxis("Mouse Y") * sensitivityY;

                //limit the vertical rotation using clamp
                verticalRot = Mathf.Clamp(verticalRot, minimumY, maximumY);

                float horizontalRot = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
            }
            else
            {
                //both horizontal and vertical rotation

                verticalRot -= Input.GetAxis("Mouse Y") * sensitivityY;
                //limit the vertical rotation using clamp
                verticalRot = Mathf.Clamp(verticalRot, minimumY, maximumY);

                //delta is the change in the horizontal rotation
                float delta = Input.GetAxis("Mouse X") * sensitivityX;
                //increment rotation angle by delta
                float horizontalRot = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
            }
        }
    }
}
