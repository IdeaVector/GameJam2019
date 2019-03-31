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

    public Text text;

    private int ageIndex = 0;
    private int age = 20;

    private List<Sprite> spriteList;
    private bool isWantToKillMutherfucker = false;
    private int killCoef = 1;

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
        ageIndex++;
        if (ageIndex > 3)
        {
            SceneManager.LoadScene("Menu");
        }
        if (ageIndex <= 3)
        currentSprite.GetComponent<SpriteRenderer>().sprite = spriteList[ageIndex];
        faceImage.sprite = spriteList[ageIndex];
    }

    public void AddAge(int value)
    {
        age += value;
        if (ageIndex == 0 && age >= 35)
        {
            NextFace();
        }
        if (ageIndex == 1 && age >= 50)
        {
            NextFace();
        }
        if (ageIndex == 2 && age >= 65)
        {
            NextFace();
        }
        if (ageIndex == 3 && age >= 80)
        {
            NextFace();
        }
        text.text = age.ToString();
    }

    private bool isReady = true;

    private int counter = 0;

    private void Update()
    {
        if (isWantToKillMutherfucker)
        {
            if (counter == 0)
            {
                AddAge(killCoef);
            }
            counter++;
            if (counter >= 5)
            {
                counter = 0;
            }
        }
    }

    public void killMatherfucker(int coef)
    {
        killCoef = coef;
        isWantToKillMutherfucker = true;
    }

    public void saveMatherfucker()
    {
        killCoef = 1;
        isWantToKillMutherfucker = false;
    }
}
