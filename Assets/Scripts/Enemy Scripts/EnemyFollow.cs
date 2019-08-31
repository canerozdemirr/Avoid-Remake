using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private float speed = 2;

    private Transform playerPos;

    public AudioClip enemySpawn;

    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
        SoundManager.instance.PlaySoundFX(enemySpawn);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }
}
