using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotPlayerScript : MonoBehaviour
{
    public Button qButton;
    public Button wButton;
    public Button eButton;
    public Button rButton;
    private List<Button> buttonList;

    public Color currentColor = Color.green;
    public float speed = 10; // скорость пули
    public GameObject bulletSprite;
    private Rigidbody2D bullet; // префаб нашей пули
    public Transform gunPoint; // точка рождения
    public float fireRate = 1; // скорострельность

    public Transform zRotate; // объект для вращения по оси Z

    // ограничение вращения
    public float minAngle = -80;
    public float maxAngle = 80;

    private float curTimeout;

    void Start()
    {
        bullet = bulletSprite.GetComponent<Rigidbody2D>();
        setBrushColor(Color.green);
        buttonList = new List<Button>();
        buttonList.Add(qButton);
        buttonList.Add(wButton);
        buttonList.Add(eButton);
        buttonList.Add(rButton);

        setAllTransparent();
        setNotTransparent(qButton);
    }

    void SetRotation()
    {
        Vector3 mousePosMain = Input.mousePosition;
        mousePosMain.z = Camera.main.transform.position.z;
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosMain);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, minAngle, maxAngle);
        if (angle > maxAngle)
        {
            angle = maxAngle - 1f;
        }
        if (angle < minAngle)
        {
            angle = minAngle + 1f;
        }
        zRotate.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
        else
        {
            curTimeout = 100;
        }
        if (zRotate) SetRotation();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            setAllTransparent();
            setNotTransparent(qButton);
            setBrushColor(Color.green);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            setAllTransparent();
            setNotTransparent(wButton);
            setBrushColor(Color.red);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            setAllTransparent();
            setNotTransparent(eButton);
            setBrushColor(Color.blue);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            setAllTransparent();
            setNotTransparent(rButton);
            setBrushColor(Color.white);
        }
    }

    void Fire()
    {
        curTimeout += Time.deltaTime;
        if (curTimeout > fireRate)
        {
            curTimeout = 0;
            Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;
            clone.velocity = transform.TransformDirection(gunPoint.right * speed);
            clone.transform.right = gunPoint.right;
        }
    }

    private void setBrushColor(Color newColor)
    {
        currentColor = newColor;
        BrushScript script = bulletSprite.GetComponent<BrushScript>();
        script.color = currentColor;
    }

    void setTransparent(Button button)
    {
        Color buttonColor = button.colors.normalColor;
        buttonColor.a = 0f;
        ColorBlock colors = button.colors;
        colors.normalColor = buttonColor;
        button.colors = colors;
    }

    void setAllTransparent()
    {
        foreach (Button button in buttonList)
        {
            setTransparent(button);
        }
    }

    void setNotTransparent(Button button)
    {
        Color buttonColor = button.colors.normalColor;
        buttonColor.a = 100f;
        ColorBlock colors = button.colors;
        colors.normalColor = buttonColor;
        button.colors = colors;
    }
}
