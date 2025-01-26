using System.Linq;
using UnityEngine;

public class DoorChecker : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    private void Update()
    {
        if (enemies.All(x => x == null))
        {
            gameObject.SetActive(false);
        }
    }
}