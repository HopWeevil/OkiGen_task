using DG.Tweening;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class PopupText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _duration;
    public void PlayAnimation()
    {
        _text.DOFade(0f, _duration);
        transform.DOMove(transform.position + Vector3.up, _duration).OnComplete(() => {
            Destroy(gameObject);
        });
    }
}
