using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceToRetry : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(2);
        }
    }
}
