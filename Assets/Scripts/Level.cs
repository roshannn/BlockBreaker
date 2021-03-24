using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{   
    //parameters
    [SerializeField] int breakableBlocks;
    [SerializeField] int ballCount;
    //cached references
    SceneLoader sl;

    private void Start()
    {
        sl = FindObjectOfType<SceneLoader>();
    }
    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void CountBalls()
    {
        ballCount++;
    }
    
    public void BlockDestroyed()
    {
        breakableBlocks--;
            if (breakableBlocks <= 0)
        {
            sl.LoadNextScene();
        }
    }

    public void AllBallsGone()
    {
        ballCount--;
        if (ballCount <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
    
}
