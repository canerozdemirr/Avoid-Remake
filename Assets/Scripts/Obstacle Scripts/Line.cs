using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public GameObject damageEffect;

    public AudioClip[] hitClips;

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Point") { 
            Instantiate(damageEffect, target.transform.position, Quaternion.identity);
            Destroy(target.gameObject);
            StartCoroutine(ObstacleSpawner.instance.SpawnAPoint());
            SoundManager.instance.PlaySoundFX(hitClips[Random.Range(0, hitClips.Length)]);
        }
    }
}
