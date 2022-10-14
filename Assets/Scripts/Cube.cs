using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _speed;
    private float _distance;

    private Vector3 _startPos;

    private void Start()
    {
        _startPos = transform.position;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetDistance(float distance)
    {
        _distance = distance;
    }

    private void Update()
    {
        if (transform.position.y >= _startPos.y + _distance)
        {
            Hide();
        }

        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        transform.position = _startPos;
    }
}
