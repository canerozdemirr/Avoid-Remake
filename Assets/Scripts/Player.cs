﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float xBound, yBound;

    public GameObject damageEffect;

    public AudioClip pointPickUP;
    public AudioClip[] hitClips;

    void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);   
        target.z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //Bounds
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -xBound, xBound), Mathf.Clamp(transform.position.y, -yBound, yBound));
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Point"))
        {
            GameManager.instance.IncreseScore();
            Destroy(target.gameObject);
            StartCoroutine(GameObject.FindObjectOfType<ObstacleSpawner>().SpawnAPoint());
            SoundManager.instance.PlaySoundFX(pointPickUP);
        }

        if(target.tag == "Obstacle" || target.tag == "Enemy")
        {
            SoundManager.instance.PlaySoundFX(hitClips[Random.Range(0, hitClips.Length)]);
            Instantiate(damageEffect, transform.position, Quaternion.identity);
            GameManager.instance.isDead = true;
            gameObject.SetActive(false);
        }

    }

}
