using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    private Camera _camera;
    private Player _player;
    private Vector3 _point;
    private Rigidbody _rigidbody;

    public void Initialize(Player player, Camera camera)
    {
        _camera = camera;
        _player = player;
        _rigidbody = _player.GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GetDirectionToMove();
            _player.transform.LookAt(_point);
            _rigidbody?.AddRelativeForce(Vector3.forward * _speed);
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
    
}
