using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honey : MonoBehaviour
{
    public GameObject honeyFx;
    public AudioClip coinSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(honeyFx, this.gameObject.transform);
            GameObject soundObject = new GameObject("CollisionSound");
            AudioSource audioSource = soundObject.AddComponent<AudioSource>();
            audioSource.clip = coinSound;
            audioSource.Play();
            Destroy(soundObject, coinSound.length);
            Destroy(gameObject, 0.5f);
        }

    }
}
