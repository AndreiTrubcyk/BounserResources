using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _playerPrefab;
    [SerializeField] private Transform _candyPrefab;
    [SerializeField] private Transform _presentPrefab;

    public Transform PlayerSpawning()
    {
        return Instantiate(_playerPrefab);
    }

    public Transform PresentsSpawning(Vector3 randomPoint, Transform parentForPresents, Color color)
    {
        var present = Instantiate(_presentPrefab, randomPoint, Quaternion.identity, parentForPresents);
        present.transform.GetChild(0).GetComponent<Renderer>().materials[1].color = color;
        return present;
    }

    public Transform CandySpawning(Vector3 randomPoint, Color color)
    {
        var candy = Instantiate(_candyPrefab, randomPoint, Quaternion.identity);
        candy.transform.GetChild(0).GetComponent<Renderer>().materials[0].color = color;
        candy.Rotate(90, 0, 90);
        return candy;
    }
}
