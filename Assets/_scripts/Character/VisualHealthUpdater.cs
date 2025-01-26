using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class VisualHealthUpdater : MonoBehaviour
{
    [FormerlySerializedAs("healthPlayer")] 
    [SerializeField] private int _healthPlayer;
    [SerializeField] private int _maxHealthPlayer;
    [SerializeField] private Image _imageHealthFeedback;
    [SerializeField] private Sprite _fullHealthTexture;
    [SerializeField] private Sprite _halfHealthTexture;
    [SerializeField] private Sprite _lowHealthTexture;
    [SerializeField] private Sprite _singleHPLeft;
    Sprite textureToApply = null; 
    private void Start()
    {
        Player.HealthChanged += OnPlayerHealthChanged;
        _maxHealthPlayer = Player.instance.MaxHealth;
        _imageHealthFeedback = GetComponent<Image>();
    }

    private void OnDestroy()
    {
        Player.HealthChanged -= OnPlayerHealthChanged;
    }

    private void OnPlayerHealthChanged(int newHealth)
    {

        if (newHealth == 1)
        {
            textureToApply = _singleHPLeft;
        }
        if ( newHealth >= _maxHealthPlayer / 4) 
        {
            textureToApply = _lowHealthTexture;
        }
        
        if (newHealth >= _maxHealthPlayer / 2)
        {
            textureToApply = _halfHealthTexture;
        }

        if (newHealth >= _maxHealthPlayer)
        {
            textureToApply = _fullHealthTexture;
        }
        
        _imageHealthFeedback.sprite = textureToApply;
    }
    
}