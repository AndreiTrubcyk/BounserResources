using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PresentsSpawner : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _present;
    [SerializeField] private Transform _perentForPresents;
    [SerializeField] private int _presentsCount = 6;
    private List<GameObject> _boxes;

    private void Awake()
    {
        for (int i = 0; i < _presentsCount; i++)
        {
            var newVector = _gameManager.RandomPoint();
            var gameObject = Instantiate(_present, newVector, Quaternion.identity, _perentForPresents);
            _boxes.Add(gameObject);
            gameObject.transform.GetChild(0).GetComponent<Renderer>().materials[1].
                color = _gameManager.SetRandomColor();
        }
    }
    
}
