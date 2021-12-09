using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    private int rando;

    public enum SpriteStatus { open1 = 0, closed1 = 1}
    public SpriteStatus spriteState;

    void Start()
    {
        OnMouseClick();
    }
    void Update()
    {
        rando = Random.Range(0, 1);
        spriteRenderer.sprite = spriteArray[(int)spriteState];
        

    }
    public void OnMouseClick()
    {
            spriteState = SpriteStatus.closed1;

    }
    
}
