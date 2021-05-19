using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class LevelManager : Singleton<LevelManager>
{
    public List<Level> Levels;
    public int currentLevelID = 1;
    public Level level;

    public void LoadLevel(int levelID)
    {
        this.level = Instantiate<Level>(Levels[levelID - 1]);
        this.currentLevelID = levelID;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
