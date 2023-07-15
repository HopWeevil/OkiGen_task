using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _collectAmount;
    [SerializeField] private Image _icon;
    [SerializeField] private string _collectAmountTemplate;

    private Mission _mission;

    public void Render(Mission mission)
    {
        _mission = mission;
        _icon.sprite = mission.Icon;
        SetLabelText();
        SetCollectAmountText();
    }

    private void Start()
    {
        _mission.StateUpdated += OnStateUpdated;
    }

    private void OnDisable()
    {
        _mission.StateUpdated -= OnStateUpdated;
    }

    private void OnStateUpdated()
    {
        SetCollectAmountText();
    }

    private void SetCollectAmountText()
    {
        _collectAmount.text = string.Format(_collectAmountTemplate, _mission.CurrentCollectAmount, _mission.TargetCollectAmount);
    }

    private void SetLabelText()
    {
        _lable.text = string.Format(_mission.Lable, _mission.TargetCollectAmount);
    }
}