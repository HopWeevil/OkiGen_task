using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPicker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Camera _camera;
 
    private void Update()
    {   
        if (Input.GetMouseButtonDown(0) && _player.Busy == false)
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Food pickUp))
                {
                    _player.MoveHandToFood(pickUp);
                }
            }          
        }
    }
}