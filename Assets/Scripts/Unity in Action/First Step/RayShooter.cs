using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityInAction
{
    public class RayShooter : MonoBehaviour
    {
        private Camera cam;
        // Start is called before the first frame update
        void Start()
        {
            cam = GetComponent<Camera>();

            //lock the cursor to the middle of the screen
            Cursor.lockState = CursorLockMode.Locked;
            //hide the cursor
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                //middle of the screen is half the width and height of the screen
                Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0);
                //create ray from mouse position to the middle of the screen
                Ray ray = cam.ScreenPointToRay(point);
                RaycastHit hit;
                //raycast filled a referenced variable with information
                if(Physics.Raycast(ray, out hit))
                {
                    //if we hit something
                    // Debug.Log("You clicked on " + hit.transform.name);
                    GameObject hitObject = hit.transform.gameObject;
                    ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                    if(target != null)
                    {
                        // Debug.Log("target hit");
                        target.ReactToHit();
                    }
                    else
                    {
                        //startcoroutine sets coroutine in motions
                        //Once a coroutine is started, it keeps running until the function is finished; it pauses along the way.
                        StartCoroutine(SphereIndicator(hit.point));
                    }

                }
            }
        }

        /**
        Technically, coroutines aren’t asynchronous (asynchronous operations don’t stop
        the rest of the code from running; think of downloading an image in the script of a
        website),
        but through clever use of enumerators, Unity makes coroutines behave similarly to asynchronous functions.
        */
        IEnumerator SphereIndicator(Vector3 hitPoint)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = hitPoint;

            //yield = keyword causes the coroutine to temporarily pause
            yield return new WaitForSeconds(1);

            Destroy(sphere);
        }

        private void OnGUI()
        {
            int size = 12;
            float posX = cam.pixelWidth/2 - size/4;
            float posY = cam.pixelHeight/2 - size/2;

            GUI.Label(new Rect(posX, posY, size, size), "*");
        }
    }
}
