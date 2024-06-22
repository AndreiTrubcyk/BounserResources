using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _presentsCount = 6;
    [SerializeField] private float _playerSpeed = 3;
    [SerializeField] private Color[] _colors;
    [SerializeField] private Collider _gameBoard;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _parentForPresents;
    [SerializeField] private Spawner _spawner;
    private Player _player;
    private Candy _candy;
    private List<Present> _presents = new ();

    private void Awake()
    {
        SpawnAllObjects();
        InitializeAllObjects();
        _player.TakeCandyColor += _candy.ReturnColor;
        _player.SpawnAnotherCandy += SpawnOne;
        _player.TakeTagForCorrectPresents += TakeTagForPresents;
    }

    private void TakeTagForPresents()
    {
        foreach (var present in _presents)
        {
            if (_player.ReturnColor() == present.ReturnColor())
            {
                present.tag = "Box";
            }
        }
    }
    
    public Color SetRandomColor()
    {
        return _colors[Random.Range(0, _colors.Length)];
    }

    private void SpawnOne()
    {
        if (_candy != null)
        {
            Destroy(_candy.gameObject);
            _player.TakeCandyColor -= _candy.ReturnColor;
        }
        var newCandy = _spawner.CandySpawning(RandomPoint(), SetRandomColor());
        _candy = newCandy.GetComponent<Candy>();
        _candy.Initialize();
        _player.TakeCandyColor += _candy.ReturnColor;
    }

    public Vector3 RandomPoint()
    {
        var bounds = _gameBoard.bounds;
        var randomX = Random.Range(bounds.min.x, bounds.max.x);
        var randomZ = Random.Range(bounds.min.z, bounds.max.z);
        return new Vector3(randomX, 0, randomZ);
    }

    private void SpawnAllObjects()
    {
        var player = _spawner.PlayerSpawning();
        _player = player.GetComponent<Player>();
        var candy = _spawner.CandySpawning(RandomPoint(), SetRandomColor());
        _candy = candy.GetComponent<Candy>();
        for (int i = 0; i < _presentsCount; i++)
        {
            var present = _spawner.PresentsSpawning(RandomPoint(), _parentForPresents, SetRandomColor());
            _presents.Add(present.GetComponent<Present>());
        }
    }

    private void InitializeAllObjects()
    {
        _player.Initialize(_playerSpeed, _camera);
        _candy.Initialize();
        foreach (var present in _presents)
        {
            present.Initialize();
        }
    }
}
