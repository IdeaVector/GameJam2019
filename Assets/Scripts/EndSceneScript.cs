using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneScript : MonoBehaviour
{

    public Text createCount;
    public Text loseCount;
    public Text resultLabel;

    const string badFrase = "Ты жалок и ничкемен\nО тебе никто не будет вспоминать...";
    const string midleFrase = "Ты прожил не самую худшую жизнь,\nтвои картины еще поживут в воспоминаниях людей,\nпрежде чем катунь в небытие...";
    const string goodFrase = "Невероятно! Ты действительно гений.\nТы со своими картинами войдешь в историю навсегда!";

    void Start()
    {
        int createScore = PlayerPrefs.GetInt("Painted");
        int loseScore = PlayerPrefs.GetInt("Unpainted");
        createCount.text = createScore.ToString();
        loseCount.text = loseScore.ToString();

        if ((createScore - loseScore) > 10)
        {
            if((createScore - loseScore) > 20)
            {
                resultLabel.text = goodFrase;
            }
            else
            {
                resultLabel.text = midleFrase;
            }
        }
        else
        {
            resultLabel.text = badFrase;
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
