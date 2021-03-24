using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    Level lvl;
    private void Start()
    {
        lvl = FindObjectOfType<Level>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        lvl.AllBallsGone();
    }
}
