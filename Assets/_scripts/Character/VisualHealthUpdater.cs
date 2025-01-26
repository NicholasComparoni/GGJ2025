using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class VisualHealthUpdater : MonoBehaviour
{
    [FormerlySerializedAs("healthPlayer")] 
    [SerializeField] private int _healthPlayer;
    [SerializeField] private int _maxHealthPlayer;
    [SerializeField] private RawImage _rawImageHealthFeedback;
    [SerializeField] private Texture _fullHealthTexture;
    [SerializeField] private Texture _halfHealthTexture;
    [SerializeField] private Texture _lowHealthTexture;
    [SerializeField] private Texture _singleHPLeft;
    Texture textureToApply = null; 
    private void Start()
    {
        Player.HealthChanged += OnPlayerHealthChanged;
        _maxHealthPlayer = Player.instance.MaxHealth;
        _rawImageHealthFeedback = GetComponent<RawImage>();
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
        
        _rawImageHealthFeedback.texture = textureToApply;
    }
    
}