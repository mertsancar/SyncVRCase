using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed ;
    private float _timeCounter = 0f;
    private float _width = 1f;
    private float _height = 1f;

    void Update()
    {
        ChangeDirection();
        CircularMovement();
    }

    private void ChangeDirection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _speed *= -1;
        }
        
    }
    
    private void CircularMovement()
    {
        _timeCounter += Time.deltaTime * _speed;

        double x = Math.Cos(_timeCounter) * _width;
        double y = Math.Sin(_timeCounter) * _height;
        double z = 0;

        transform.position = new Vector3((float)x, (float)y, (float)z);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Enemy(Clone)")
        {
            var seq = DOTween.Sequence();
            seq.AppendInterval(0.2f);
            seq.AppendCallback(() => EventManager.Instance.TriggerEvent(EventName.LevelFailed));
        }
    }
}
