using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class slideshow1 : MonoBehaviour
{
    public GameObject[] imageArray;
    private int currentImage = 0;

    float deltaTime = 0.0f;

    public float timer1 = 5.0f;
    public float timer1Remaining = 5.0f;
    public bool timer1IsRunning = true;
    public string timer1Text;

    public void showImage()
    {
        foreach (GameObject image in imageArray)
        {
            image.SetActive(false);
        }

        if (currentImage >= 0 && currentImage < imageArray.Length)
        {
            imageArray[currentImage].SetActive(true);
        }
    }

    void Start()
    {
        currentImage = 0;
        timer1IsRunning = true;
        timer1Remaining = timer1;
        showImage();
    }

    void Update()
    {
        Cursor.visible = false;
        Screen.lockCursor = true;

        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;


        if (Input.GetMouseButtonDown(0))
        {
            currentImage++;
            if (currentImage >= imageArray.Length)
            {
                SceneManager.LoadScene(2);
                return;
            }

            showImage();
        }


        if (Input.GetKey(KeyCode.Space))
        {
            currentImage++;
            if (currentImage >= imageArray.Length)
            {
                SceneManager.LoadScene(2);
                return;
            }

            showImage();
        }


        if (timer1IsRunning)
        {
            if (timer1Remaining > 0)
            {
                timer1Remaining -= Time.deltaTime;
            }
            else
            {
                currentImage++;
                if (currentImage >= imageArray.Length)
                {
                    SceneManager.LoadScene(2);
                    return;
                }

                showImage();
                timer1Remaining = timer1;
            }
        }
    }
}