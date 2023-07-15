using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Conveyor : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Material _material;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _conveyourBeltSpeed;

    private void Start()
    {
        _material.mainTextureOffset = Vector2.zero;
    }

    private void Update()
    {
        _material.mainTextureOffset += Vector2.left * _conveyourBeltSpeed * Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, _endPoint.position, speed * Time.deltaTime);
    }

    public void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }
}