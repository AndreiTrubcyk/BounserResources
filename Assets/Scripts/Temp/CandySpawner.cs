using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField] private Transform _candy;
    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        var randomPoint = _gameManager.RandomPoint();
        _candy = Instantiate(_candy, randomPoint, Quaternion.identity);
    }
}
