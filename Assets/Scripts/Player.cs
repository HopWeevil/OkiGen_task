using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private TwoBoneIKConstraint _leftArm;
    [SerializeField] private ChainIKConstraint _rightArm;
    [SerializeField] private Transform _foodBasket;
    [SerializeField] private Transform _rightArmTarget;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _headPoint;
    [SerializeField] private Transform _dropPoint;
    [SerializeField] private Transform _handCollectPoint;

    [SerializeField] private float _headRotateSpeed;
    [SerializeField] private float _dropSpeed;
    [SerializeField] private float _rightHandSpeed;

    private Food _currentFood;
    private bool _busy;

    public bool Busy => _busy;

    public event UnityAction<Food> FoodDropped;

    public void MoveHandToFood(Food food)
    {
        _busy = true;
        _currentFood = food;
        _playerAnimator.PickUpFood();
        _headPoint.transform.DOMove(food.transform.position, _headRotateSpeed);
        MoveRightHand(food.PickUpOffset);
    }

    private void PickUpFood()
    {
        _currentFood.Freeze();
        _currentFood.SetParent(_handCollectPoint);
        MoveHandToBasket();
    }

    private void MoveHandToBasket()
    {
        MoveRightHand(_dropPoint.position, DropFood);
    }

    private void MoveRightHand(Vector3 position, TweenCallback tweenCallback = null)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_rightArmTarget.DOMove(position, _rightHandSpeed));
        sequence.OnComplete(tweenCallback);
    }

    private void DropFood()
    {
       
        _currentFood.UnFreeze();

        _currentFood.transform.DOMove(_foodBasket.transform.position, _dropSpeed).OnComplete(() => {
            _currentFood.SetParent(_foodBasket.transform);
            _busy = false;
            _playerAnimator.DropFood();
        });

        FoodDropped?.Invoke(_currentFood);
    }

    public void SetDanceState()
    {
        _playerAnimator.Dance();
    }

    public void SetIdleState()
    {
        _playerAnimator.Idle();
    }
}