using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Food : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private uint _id;
    [SerializeField] private Vector3 _pickUpOffset;
    [SerializeField] private Sprite _icon;

    [Header("Gizmos")]
    [SerializeField] private float _gizmoSize;
    [SerializeField] private Color _gizmoColor;

    private Rigidbody _rigidbody;
    public Vector3 PickUpOffset => _pickUpOffset + transform.position;
    public uint Id => _id;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent, true);
        transform.localPosition = Vector3.zero;
    }

    public void Freeze()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void UnFreeze()
    {
        _rigidbody.constraints = RigidbodyConstraints.None;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawSphere(PickUpOffset, _gizmoSize);
    }
}