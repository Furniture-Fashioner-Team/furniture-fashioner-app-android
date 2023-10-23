using System;
using UnityEngine;

public class ScreenshotController : MonoBehaviour
{
    public Camera targetCamera;

    public void TakeScreenshot()
    {
        if (targetCamera == null)
        {
            Debug.LogError("Target camera is not assigned!");
            return;
        }

        // Capture a screenshot
        string fileName = "screenshot_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
        ScreenCapture.CaptureScreenshot(fileName);
    }
}