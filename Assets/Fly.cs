using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Boarshroom.Butterfly
{
    public class Fly : MonoBehaviour
    {
        [HideInInspector] public Vector2 endPosition;
        [SerializeField] Vector2 speedMaxMin;
        float speed;
        [SerializeField] Vector2 sizeMaxMin;

        Manager manager;
        AudioSource audioSource;

        [SerializeField] GameObject deathParticle;

        private void Start()
        {
            float size = Random.Range(sizeMaxMin.x, sizeMaxMin.y);
            transform.localScale = new Vector2(size, size);

            manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
            speed = Random.Range(speedMaxMin.x, speedMaxMin.y);

            audioSource = GetComponent<AudioSource>();
            audioSource.volume = size / 20;
            audioSource.pitch = speed / 2;
        }

        private void Update()
        {
            if(!manager.end)
            {
                float step = speed * Time.deltaTime;

                transform.position = Vector2.MoveTowards(transform.position, endPosition, step);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                manager.lose = true;
                manager.end = true;
            }

            Instantiate(deathParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}