using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public enum SIDE
{
    NONE=1,
    ENEMY=2,
    PLAYER=3
}

public enum ENEMYTYPE
{
    NORMAL,
    SWING,
    FAST,
    BOSS,
}

public enum ITEMTYPE
{
    GLOD,
    APPLE,
}



public class Global
{
    public static float levelRunTime = 0;
}
