using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Canvas MenuCanvas, HUDCanvas;
    void Start()
    {
        DontDestroyOnLoad(this);
        if (MenuCanvas != null) DontDestroyOnLoad(MenuCanvas);
        if (HUDCanvas != null) DontDestroyOnLoad(HUDCanvas);
    }
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            if (MenuCanvas != null) DontDestroyOnLoad(MenuCanvas);
            CanvasGroup canvasGroup = MenuCanvas.GetComponent<CanvasGroup>();
            canvasGroup.SwitchState();
        }
    }
}
