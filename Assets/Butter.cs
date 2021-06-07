using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Boarshroom.Butterfly
{
    public class Butter : MonoBehaviour
    {
        Manager manager;

        private void Start()
        {
            manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        }

        private void Update()
        {
            if(!manager.end)
            {
                transform.localScale -= new Vector3(0, Time.deltaTime / 25, 0);

                if (transform.localScale.y <= 0.05f)
                {
                    manager.end = true;
                }
            }
        }
    }
}
