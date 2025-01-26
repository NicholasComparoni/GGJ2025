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

    private void OnEnable()
    {
        Player.HealthChanged += OnPlayerHealthChanged;
    }

    private void Awake()
    {
        _imageHealthFeedback = GetComponent<Image>();
        _maxHealthPlayer = Player.instance.MaxHealth;
    }

    private void OnDisable()
    {
        Player.HealthChanged -= OnPlayerHealthChanged;
    }

    private void OnPlayerHealthChanged(int newHealth)
    {
        if (newHealth == 1)
        {
            _imageHealthFeedback.sprite= _singleHPLeft;
            return;
        }
        if (newHealth >= _maxHealthPlayer)
        {
            _imageHealthFeedback.sprite = _fullHealthTexture;
            return;
        }
        if (newHealth >= _maxHealthPlayer / 2)
        {
            _imageHealthFeedback.sprite = _halfHealthTexture;
            return;
        }
        if (newHealth >= _maxHealthPlayer / 4)
        {
            _imageHealthFeedback.sprite = _lowHealthTexture;
        }
    }
    
}