using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    [SerializeField] float rotationSpeed;
    [SerializeField] bool inverseControls;
    [SerializeField] UIManager UIManager;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI currentScoreText;

    private bool isGameActive;
    private float horizontalInput;
    private Vector3 lastMousePos;
    private int highScore;
    private string highScoreKey = "HighScore";

    void Start()
    {
        UIManager.EnableScreen(ScreenEnum.TITLESCREEN, true);
        UIManager.EnableScreen(ScreenEnum.CURRENCYBAR, true);
        scoreManager.ResetValues();
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;

            if (!isGameActive)
            {
                isGameActive = true;
                UIManager.EnableScreen(ScreenEnum.TITLESCREEN, false);
                UIManager.EnableScreen(ScreenEnum.HUD, true);
            }
        }

        if (Input.GetMouseButton(0))
        {
            float mouseMovement = ((Input.mousePosition.x - lastMousePos.x) * (inverseControls ? 1 : -1));
            transform.Rotate(Vector3.up, mouseMovement * rotationSpeed * Time.deltaTime);
            lastMousePos = Input.mousePosition;
        }      
    }

    public void GameOver()
    {        
        isGameOver = true;
        if (scoreManager.GetScore() > PlayerPrefs.GetInt(highScoreKey, 0))
        {
            PlayerPrefs.SetInt(highScoreKey, scoreManager.GetScore());
            PlayerPrefs.Save();
            highScore = PlayerPrefs.GetInt(highScoreKey, 0);
            highScoreText.SetText("New Best: " + highScore.ToString() + "!");
        }
        else
        {
            highScoreText.SetText("Best: " + highScore.ToString());
            currentScoreText.SetText("Score: " + scoreManager.GetScore().ToString());
            currentScoreText.gameObject.SetActive(true);
        }       
        
        UIManager.EnableScreen(ScreenEnum.HUD, false);
        UIManager.EnableScreen(ScreenEnum.GAMEOVERSCREEN, true);

    }
}
