using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerCanvas : MonoBehaviour
{
    [SerializeField] private TMP_Text _ammoText;
    private Animator _animator;
    public static PlayerCanvas instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one player canvas");
            return;
        }

        instance = this;
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        instance._ammoText.text = $"{Player.instance.ammo}/{Player.instance.maxAmmoQuantity}";
    }

    public static void PlayAnimation(string triggerName)
    {
        instance._animator.SetTrigger(triggerName);
    }

    public static void UpdateAmmo(int value, int maxVlaue)
    {
        instance._ammoText.text = $"{value}/{maxVlaue}";
    }
    
}
