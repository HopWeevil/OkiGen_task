using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _lookDuration;
    [SerializeField] private Vector3 _offset;

    public void Move()
    {
        transform.DOLookAt(_player.transform.position  + _offset, _lookDuration);
        transform.DOMove(_targetPoint.position, _moveDuration);
    }
}