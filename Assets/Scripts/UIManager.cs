using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public EnumPanel[] UiScreens;

    void Start()
    {
        
    }

    public void EnableScreen(ScreenEnum screen, bool enable)
    {
        foreach (EnumPanel UIscreen in UiScreens)
        {
            if (UIscreen.ScreenType == screen)
            {
                UIscreen.gameObject.SetActive(enable);
            }
        }
    }
}
