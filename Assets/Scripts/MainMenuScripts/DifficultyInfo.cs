using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", order = 3)]
public class DifficultyInfo : ScriptableObject
{
    [SerializeField] private string _name;
    
    [SerializeField] private float _speed;
    
    [SerializeField] private float _timeToChangeSpeed;
    
    [SerializeField] private float _distToSpawnBarrier;

    public string name => _name;

    public float speed => _speed;

    public float timeToChangeSpeed => _timeToChangeSpeed;

    public float distToSpawnBarrier => _distToSpawnBarrier;
}
