using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PickupFeedbackHandler : MonoBehaviour
{
    [SerializeField] private float feedbackDuration = 1.0f;

    public void ShowFeedback(GameObject feedbackObject)
    {
        if (feedbackObject != null)
        {
            StartCoroutine(HandleFeedback(feedbackObject));
        }
    }

    private IEnumerator HandleFeedback(GameObject feedbackObject)
    {
        feedbackObject.GetComponent<RawImage>().enabled = true;
        yield return new WaitForSeconds(feedbackDuration);
        feedbackObject.GetComponent<RawImage>().enabled = false;
    }
}