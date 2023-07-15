using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MissionScreen : MonoBehaviour, IScreen
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _hidingDuration;
    [SerializeField] private float _showingDuration;

    public void Hide()
    {
        _canvasGroup.DOFade(0, _hidingDuration);
        _canvasGroup.blocksRaycasts = false;
    }

    public void Show()
    {
        _canvasGroup.DOFade(1, _hidingDuration);
        _canvasGroup.blocksRaycasts = true;
    }
}
