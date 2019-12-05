using UnityEngine;
using UnityEngine.UI;
public static class ExtensionMethods
{
    /// <summary>
    /// Switch canvas state
    /// </summary>
    /// <param name="canvasGroup"></param>
    public static void SwitchState(this CanvasGroup canvasGroup)
    {
        if (canvasGroup.interactable)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            Time.timeScale = 1;
        }
        else
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            Time.timeScale = 0;
        }
    }
}