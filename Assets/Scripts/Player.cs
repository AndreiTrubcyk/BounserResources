using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Func<Color> TakeCandyColor;
    public Action SpawnAnotherCandy;
    public Action TakeTagForCorrectPresents;
    
    private Color _playerColor;
    private Camera _camera;
    private Vector3 _point;
    private Rigidbody _rigidbody;
    private float _speed;
    public void Initialize(float speed ,Camera camera)
    {
        _speed = speed;
        _camera = camera;
        _rigidbody = transform.GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public Color ReturnColor()
    {
        return _playerColor;
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GetDirectionToMove();
            transform.LookAt(_point);
            _rigidbody.AddRelativeForce(Vector3.forward * _speed);
        }
    }
    
    private void GetDirectionToMove()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _point = hit.point;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Candy"))
        {
            var candyColor = TakeCandyColor?.Invoke();
            if (candyColor.HasValue)
            {
                _playerColor = transform.GetComponent<Renderer>().materials[0].color = candyColor.Value;
            }
            SpawnAnotherCandy.Invoke();
            TakeTagForCorrectPresents?.Invoke();
        }

        if (collision.transform.CompareTag("Box"))
        {
            Destroy(collision.gameObject);
        }
    }
}
