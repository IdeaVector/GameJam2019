using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public Image faceImage;
    public Sprite yangFace;
    public Sprite middleFace;
    public Sprite defaultFace;
    public Sprite oldFace;
    private int ageIndex = 0;

    private List<Sprite> spriteList;

    void Start()
    {
        spriteList = new List<Sprite>();
        spriteList.Add(yangFace);
        spriteList.Add(middleFace);
        spriteList.Add(defaultFace);
        spriteList.Add(oldFace);

        NextFace();
        NextFace();
        NextFace();
        NextFace();
    }

    public void NextFace()
    {
        faceImage.sprite = spriteList[ageIndex];
        ageIndex++;
    }
}
