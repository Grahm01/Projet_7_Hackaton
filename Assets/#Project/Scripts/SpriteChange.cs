using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    public enum SpriteStatus { open1 = 0, closed1 = 1}
    public SpriteStatus spriteState;

    void Start()
    {
        OnMouseClick();
    }
    void Update()
    {
        spriteRenderer.sprite = spriteArray[(int)spriteState];
        

    }
    public void OnMouseClick()
    {
            spriteState = SpriteStatus.closed1;

    }
    
}
