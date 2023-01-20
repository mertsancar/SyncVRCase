using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    void Start()
    {
        Movement();
    }

    private void Movement()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * _speed;
        _speed += Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("EnemyDeadLocation"))
        {
            Destroy(gameObject);
        }
        
    }
}
