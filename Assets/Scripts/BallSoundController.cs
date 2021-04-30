using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSoundController : MonoBehaviour
{
    [SerializeField]
    protected AudioClip[] brickSoundList;

    [SerializeField]
    protected AudioClip wallSound;

    protected AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("brick"))
        {            
            source.clip = brickSoundList[collision.gameObject.GetComponent<BrickController>().GetHitCount()];
            source.Play();
        }
        else if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("paddle"))
        {
            source.clip = wallSound;
            source.Play();
        }
        
    }
}
