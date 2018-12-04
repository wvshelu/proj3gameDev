using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookScript : MonoBehaviour {

    public int num;
    public Sprite selectedSprite;

    private SpriteRenderer sprite;
    private bool selected;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        selected = false;
    }

    private void OnMouseDown()
    {
        selected = !selected;
        if (selected)
            sprite.sprite = selectedSprite;
        else
            sprite.sprite = null;
        BookshelfScript.ToggleSelected(num, selected);
    }
}
