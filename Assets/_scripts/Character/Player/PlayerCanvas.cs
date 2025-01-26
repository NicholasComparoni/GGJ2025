using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerCanvas : MonoBehaviour
{
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

    public static void PlayAnimation(string triggerName)
    {
        instance._animator.SetTrigger(triggerName);
    }
}
