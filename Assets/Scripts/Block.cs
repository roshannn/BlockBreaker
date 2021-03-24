using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{   
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockVFX;
    [SerializeField] Sprite[] hitSprites;
    //Cached References
    Level level;

    //state variables
    [SerializeField] int timesHit; // only for debugging
    private void Start()
    {
        level = FindObjectOfType<Level>();
        if(tag == "Breakable")
        {
            timesHit = 0;
            level.CountBlocks();
        }
        
        
    }

    private void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit();

    }

    private void HandleHit()
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1; 
            if (timesHit == maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int currentSpriteIndex = timesHit - 1;
        if (hitSprites[currentSpriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[currentSpriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite missing from array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX(); 
        level.BlockDestroyed();
        FindObjectOfType<GameSession>().AddToScore();
        TriggerBlockVFX();

    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject, 0.1f);
    }

    private void TriggerBlockVFX()
    {
        GameObject sparkles = Instantiate(blockVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2);
    }
}
