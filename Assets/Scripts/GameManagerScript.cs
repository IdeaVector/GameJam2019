using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public Image faceImage;
    public GameObject currentSprite;
    public Sprite yangFace;
    public Sprite middleFace;
    public Sprite defaultFace;
    public Sprite oldFace;
    private int ageIndex = 0;
    private int age = 20;

    private List<Sprite> spriteList;

    void Start()
    {
        spriteList = new List<Sprite>();
        spriteList.Add(yangFace);
        spriteList.Add(middleFace);
        spriteList.Add(defaultFace);
        spriteList.Add(oldFace);
    }

    public void NextFace()
    {
        faceImage.sprite = spriteList[ageIndex];
        currentSprite.GetComponent<SpriteRenderer>().sprite = spriteList[ageIndex];
        ageIndex++;

        if(ageIndex >3)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
