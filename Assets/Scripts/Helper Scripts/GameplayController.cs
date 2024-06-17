using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI stairText;
    [SerializeField] private GameObject finalScorePanel; // Reference to your "Final Score" panel
    private int score = 0;
    private int stair;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();

    }

    public void IncrementStair()
    {
        stair++;
        stairText.text = stair.ToString();
    }

    public void ShowPanelDied()
    {
        StartCoroutine(ShowPanelAfterDelay());
    }

    public IEnumerator ShowPanelAfterDelay()
    {
        yield return new WaitForSeconds(0f); 
        Debug.Log("End Game");
        finalScorePanel.SetActive(true);
        RestartGame();
    }

    public void RestartGame()
    {
        Invoke("ReloadGame", 3f);
    }

    void ReloadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }


 
}
