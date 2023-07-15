using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelPassScreen : MonoBehaviour, IScreen
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private LevelPassedText _levelPassedText;
    [SerializeField] private float _showingDuration;

    public event UnityAction NextLevelButtonClick;

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
    }

    public void Show()
    {
        _canvasGroup.DOFade(1, _showingDuration);
        _levelPassedText.PlayAnimation();
    }

    public void Hide()
    {
        _canvasGroup.blocksRaycasts = false;
    }

    private void OnNextLevelButtonClick()
    {
        NextLevelButtonClick?.Invoke();
    }
}