using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    int score = 0;
    public TextMeshProUGUI scoreText;
    
    public  GameObject gameOverPanel;
    public  GameObject startPanel;
    public GameObject enemyHPSlider;

    public GameObject rockGenerator;

    public BossController bossController;
    

    void Start () {
        gameOverPanel.SetActive(false);
        startPanel.SetActive(true);
        rockGenerator.SetActive(false);
        enemyHPSlider.SetActive(false);
        bossController.enabled = false;
    }

    public void CloseStartMenu()
    {
        startPanel.SetActive(false);
        rockGenerator.SetActive(true);
        enemyHPSlider.SetActive(true);
        bossController.enabled = true;

    }
    
    public void GameOver(){
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(){
        this.score += 10;
        //scoreText.text = "Score:" + score.ToString("D4");
        scoreText.text = score.ToString("D4");

    }

    void Update () {
    }
}