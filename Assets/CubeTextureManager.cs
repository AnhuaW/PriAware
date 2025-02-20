using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTextureManager : MonoBehaviour
{
    public int index = 0;
    public List<Sprite> slices = new List<Sprite>();

    public List<SpriteRenderer> sprites = new List<SpriteRenderer>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("mapping texture to cube "+ index);
        for (int i = 0; i < sprites.Count; i++)
        {
            int sliceIndex = i + index;
            if (i + index > slices.Count)
            {
                sliceIndex = i + index - slices.Count;
            }
            sprites[i].sprite = slices[sliceIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
