using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapFeature : MonoBehaviour
{
    //This script detects if you have tapped on the screen. This might be useful if you want a double tap feature in your game somewhere, just make sure to reference to the Doubletap boolean from this script and you're good to go!

    float lastTaptime = 0;
    float doubleTapTreshhold = 0.3f;

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    public bool DoubleTap;


    private void Start()
    {
        dragDistance = Screen.height * 10 / 100; //dragDistance is 15% height of the screen
        DoubleTap = false;
    }

    private void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;


                if (Time.time - lastTaptime <= doubleTapTreshhold) {
                    lastTaptime = 0;
                    DoubleTap = true;
                }
                else
                {
                    lastTaptime = Time.time;
                    DoubleTap = false;
                }
            }
        }
        else{
            DoubleTap = false;
        }
    }
}
