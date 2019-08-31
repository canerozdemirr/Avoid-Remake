﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    private float speed = .17f;

    void Start()
    {
        speed = Random.Range(.23f, .26f);
    }

    void Update()
    {
        if (Time.timeScale == 0) return;

        if (GameObject.FindObjectOfType<ObstacleSpawner>().up)
        {
            transform.Translate(new Vector2(0, -speed * 0.12f));

            if (transform.position.y <= -6)
            {
                ObstacleSpawner.instance.up = false;
                ObstacleSpawner.instance.SpawnHorizontal();
                Destroy(gameObject);
            }
        }
        else
        {
            transform.Translate(new Vector2(0, speed * 0.12f));

            if (transform.position.y >= 6)
            {
                ObstacleSpawner.instance.up = true;
                ObstacleSpawner.instance.SpawnHorizontal();
                Destroy(gameObject);
            }

        }
    }
}
