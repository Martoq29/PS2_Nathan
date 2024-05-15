using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apearence : MonoBehaviour
{

    public int skinNr;

    public Skins[] skins;

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SkinChoice();
    }

    void SkinChoice()
    {
        if (spriteRenderer.sprite.name.Contains("Capsule"))
        {
            string spriteName = spriteRenderer.sprite.name;
            spriteName = spriteName.Replace("Capsule", "");
            int spriteNr = int.Parse(spriteName);

            spriteRenderer.sprite = skins[skinNr].sprites[spriteNr];
        }
    }

    
}
[System.Serializable]
public struct Skins
{
    public Sprite[] sprites;
}
