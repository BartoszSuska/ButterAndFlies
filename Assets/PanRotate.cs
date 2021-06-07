using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Boarshroom.Butterfly
{
    public class PanRotate : MonoBehaviour
    {
        [SerializeField] float speed;

        Manager manager;

        private void Start()
        {
            manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        }

        private void Update()
        {
            if(!manager.end)
            {
                if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
                {
                    Debug.Log(transform.rotation.eulerAngles.z);
                    float turnSpeed = speed * Time.deltaTime;
                    float rotate = Input.GetAxis("Horizontal") * turnSpeed;
                    gameObject.transform.Rotate(Vector3.back * rotate);
                }

                if (transform.rotation.eulerAngles.z >= 15 && transform.rotation.eulerAngles.z < 20)
                {
                    transform.eulerAngles = new Vector3(0, 0, 14.9f);
                }
                if (transform.rotation.eulerAngles.z <= 345 && transform.rotation.eulerAngles.z > 340)
                {
                    transform.eulerAngles = new Vector3(0, 0, -14.9f);
                }
            }
        }
    }
}
