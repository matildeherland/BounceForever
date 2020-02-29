using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public EnumPanel[] UIscreens;

    void Start()
    {
        
    }

    public void EnableScreen(ScreenEnum screen, bool enable)
    {
        foreach (EnumPanel UIscreen in UIscreens)
        {
            if (UIscreen.ScreenType == screen)
            {
                UIscreen.gameObject.SetActive(enable);
            }
        }
    }
}
