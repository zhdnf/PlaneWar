using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
*/

/// <summary>
///
/// </summary>

public class GameOver : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Back()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
