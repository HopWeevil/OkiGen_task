using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Mission
{
    [SerializeField] private Food _collectFood;
    [SerializeField] private Vector2Int _collectAmountRange;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _lable;

    private int _targetCollectAmount;
    private int _currentCollectAmount;

    public Sprite Icon => _icon;
    public string Lable => _lable;
    public int TargetCollectAmount => _targetCollectAmount;
    public int CurrentCollectAmount => _currentCollectAmount;

    public event UnityAction StateUpdated;
    public event UnityAction MissionComplete;

    public void Create()
    {
        _targetCollectAmount = Random.Range(_collectAmountRange.x, _collectAmountRange.y);
    }

    public void TryUpdateState(Food food)
    {
        if (food.Id == _collectFood.Id)
        {
            _currentCollectAmount++;
            StateUpdated?.Invoke();

            if(_currentCollectAmount == _targetCollectAmount)
            {
                MissionComplete?.Invoke();
            }
        }
    }
}