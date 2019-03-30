using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour
{
    public Text firstLabel;
    public Text secondLabel;
    public Text thirdLabel;
    public Text fouthLabel;
    private float alpha = 0f;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        color = firstLabel.color;
        color.a = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        showLabels();
    }
    

    void showLabels()
    {
        if (alpha < 100f)
        {
            alpha += 0.002f;
            color.a = alpha;
            firstLabel.color = color;
            secondLabel.color = color;
            thirdLabel.color = color;
            fouthLabel.color = color;
        }
    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
}
