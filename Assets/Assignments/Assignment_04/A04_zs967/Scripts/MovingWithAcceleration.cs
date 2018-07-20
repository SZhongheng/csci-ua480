using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace A04zs96
{
    public class MovingWithAcceleration : MonoBehaviour
    {
        public float maxspeed = 6f;
        public float timezerotomax = 3f;
        public float timemaxtozero = 3f;
        float accelratepersec;
        float deccelratepersec;
        float forwardvelocity;

        // Use this for initialization
        void Start()
        {
            accelratepersec = maxspeed / timezerotomax;
            deccelratepersec = -maxspeed / timemaxtozero;
            forwardvelocity = 0f;
        }

        // Update is called once per frame
         void Update()
        {
            if (Input.GetMouseButton(0)){
                forwardvelocity += accelratepersec * Time.deltaTime;
                forwardvelocity = Mathf.Min(forwardvelocity, maxspeed);
                Vector3 forward = Camera.main.transform.forward;
                transform.Translate(forward * forwardvelocity);
            }
            else {
                forwardvelocity += deccelratepersec * Time.deltaTime;
                forwardvelocity = Mathf.Max(forwardvelocity, 0);
                Vector3 forward = Camera.main.transform.forward;
                transform.Translate(forward * forwardvelocity);
            }
        }
    }
}