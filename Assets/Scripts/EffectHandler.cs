using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _confetti;
    [SerializeField] private PopupText _popupText;

    public void PlayConfettiEffect()
    {
        _confetti.Play();
    }

    public void PlayTextPopupEffect(Transform spawnPoint)
    {
        Instantiate(_popupText, spawnPoint.position, Quaternion.identity).PlayAnimation();
    }
}