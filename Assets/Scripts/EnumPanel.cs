using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScreenEnum
{
    NONE,
    TITLESCREEN,
    HUD,
    GAMEOVERSCREEN,
}

public class EnumPanel : MonoBehaviour
{
    public ScreenEnum ScreenType;
}
