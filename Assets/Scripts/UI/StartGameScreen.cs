using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class StartGameScreen : MonoBehaviour, IScreen
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private float _showingDuration;

    public event UnityAction StartGameButtonClick;

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(OnStartGameButtonClick);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnStartGameButtonClick);
    }

    public void Show()
    {
        _canvasGroup.DOFade(1, _showingDuration);
        _canvasGroup.blocksRaycasts = false;
    }

    public void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }

    private void OnStartGameButtonClick()
    {
        StartGameButtonClick?.Invoke();
    }

}