using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class slideshow1 : MonoBehaviour
{
    
    public Texture[] imageArray; 
    private int currentImage;
        
    float deltaTime = 0.0f;
 
    public float timer1 = 5.0f;
    public float timer1Remaining = 5.0f;
    public bool timer1IsRunning = true;
    public string timer1Text;
    
    void OnGUI()
    {
        
        int w = Screen.width, h = Screen.height;
        
        Rect imageRect = new Rect(0, 0, Screen.width, Screen.height);
        

        GUI.DrawTexture(imageRect, imageArray[currentImage]);

        if(currentImage >= imageArray.Length)
            currentImage = 0;
    }
 
    void Start()
    {
        currentImage = 0;
        bool timer1IsRunning = true;
        timer1Remaining = timer1;
     }
 
    void Update()
    {
        Cursor.visible= false;
        Screen.lockCursor = true;
                
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            
            if (Input.GetMouseButtonDown(0))
            {
                    currentImage++;
        
                if(currentImage >= imageArray.Length)
                    currentImage = 0;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                currentImage++;

                if (currentImage >= imageArray.Length)
                    SceneManager.LoadScene(2);
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
        
                    if(currentImage >= imageArray.Length)
                        SceneManager.LoadScene(2);
                
                    timer1Remaining = timer1;
                }
            }
        
    }
}
