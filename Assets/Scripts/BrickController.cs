using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField]
    Sprite[] spriteList;

    int hitCount, maxHits;

    // Start is called before the first frame update
    void Start()
    {
        hitCount = 0;
        maxHits = spriteList.Length;
        GetComponent<SpriteRenderer>().sprite = spriteList[hitCount];
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        hitCount++;
        if(hitCount == maxHits)
        {
            Destroy(gameObject);
        } else
        {
            GetComponent<SpriteRenderer>().sprite = spriteList[hitCount];
        }
    }

    public int GetHitCount()
    {
        return hitCount;
    }

}
