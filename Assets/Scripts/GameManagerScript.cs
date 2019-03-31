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

    public Text gameText;
    public GameObject deathObj;

    private int ageIndex = 0;
    private int age =20;
    private bool isFlashing = false;
    private float timer = 0f;

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

    void Awake()
    {
        PlayerPrefs.SetInt("Painted", 0);
        PlayerPrefs.SetInt("Unpainted", 0);

        hideDeath();
    }



    public void NextFace()
    {
        ageIndex++;
        if (ageIndex > 3)
        {
            SceneManager.LoadScene("EndGame");
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
            showDeath();
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

        if (isFlashing)
        {
            timer += Time.deltaTime;

            if (timer >= 0.5)
            {
                Color color = gameText.GetComponent<Text>().color;
                color.a = 0f;
                gameText.GetComponent<Text>().color = color;
            }
            if (timer >= 1)
            {
                Color color = gameText.GetComponent<Text>().color;
                color.a = 100f;
                gameText.GetComponent<Text>().color = color;
                timer = 0;
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

    void showDeath()
    {
        Color color;
        color = gameText.color;
        color.a = 100f;
        gameText.color = color;
        gameText.text = "Твое время на исходе...";
        deathObj.SetActive(true);
        isFlashing = true;

    }

    void hideDeath()
    {
        Color color;
        color = gameText.color;
        color.a = 0f;
        gameText.color = color;
        gameText.text = "Твое время на исходе...";
        deathObj.SetActive(false);
    }
}
