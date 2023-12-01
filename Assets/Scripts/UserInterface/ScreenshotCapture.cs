using System.Collections;
using UnityEngine;

public class ScreenshotCapture : MonoBehaviour
{
    // Set the folder name where screenshots will be saved
    private string screenshotFolder = "Pictures";

    // Capture and save a screenshot
    public void CaptureScreenshot()
    {
        StartCoroutine(TakeAndSaveScreenshot());
    }

    // Coroutine to handle screenshot capture and saving
    private IEnumerator TakeAndSaveScreenshot()
    {
        // Capture the screenshot
        yield return new WaitForEndOfFrame();
        Texture2D screenshotTexture = ScreenCapture.CaptureScreenshotAsTexture();

        // Save the screenshot to the gallery
        if (screenshotTexture != null)
        {
            string filename = "Screenshot_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            SaveScreenshotToGallery(screenshotTexture, screenshotFolder, filename);
        }
    }

    // Save the screenshot to the gallery using NativeGallery
    private void SaveScreenshotToGallery(Texture2D screenshot, string album, string filename)
    {
        byte[] screenshotBytes = screenshot.EncodeToPNG();
        NativeGallery.SaveImageToGallery(screenshotBytes, album, filename, OnMediaSaveCallback);
    }

    // Callback function for media save operation
    private void OnMediaSaveCallback(bool success, string path)
    {
        if (success)
        {
            Debug.Log("Screenshot saved to: " + path);
        }
        else
        {
            Debug.LogError("Failed to save screenshot.");
        }
    }
}