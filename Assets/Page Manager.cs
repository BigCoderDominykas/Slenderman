using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public int pages;
    public Enemy enemy;
    public Enemy enemy2;
    public AudioClip pagePickUp;
    public AudioClip wake1;
    public AudioClip wake2;
    public AudioClip scarySound;
    public AudioClip veryScarySound;

    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        pages++;
        source.PlayOneShot(pagePickUp);

        if (pages == 1)
        {
            // ai wake up
            enemy.target = transform;
            source.PlayOneShot(wake1);
        }

        if (pages == 2) 
        {
            enemy.speed *= 2;
            source.PlayOneShot(scarySound);
        }

        if (pages == 3)
        {
            enemy2.target = transform;
            source.PlayOneShot(wake2);
        }

        if (pages == 4)
        {
            enemy2.speed *= 2;
            source.PlayOneShot(scarySound);
        }

        if (pages == 5) 
        {
            enemy.viewDistance *= 2;
            enemy2.viewDistance *= 2;
            source.PlayOneShot(veryScarySound);
        }
    }
}
