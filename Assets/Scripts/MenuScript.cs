using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public Texture2D cursorTexture;

    private void Start()
    {
        CursorMode cursorMode = CursorMode.Auto;
        Vector2 hotSpot = Vector2.zero;
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Start");
    }
}
