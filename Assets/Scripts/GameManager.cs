using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour{
    public int health = 3;
    public int score = 0;
    public int highscore = 0;
    private string highscoreKey = "highscore";
    public static GameManager get;
    [Header("Pause Attributes")]
    public TextMeshProUGUI pauseButtonTMP;
    public bool isPause = false;

    [Header("HUD Attributes")]
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI scoreText;
    [Header("Game Over Attributes")]
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI gameOverScoreTMP;
    [SerializeField] TextMeshProUGUI gameOverHSTMP;
    [SerializeField] AudioSource gameOverAudioSource;
    [Header("Main Menu Attributes")]
    [SerializeField] GameObject mainMenuPanel;
    // [SerializeField] TextMeshProUGUI gameOverScoreTMP;
    [SerializeField] TextMeshProUGUI mainMenuHSTMP;
    // [SerializeField] AudioSource gameOverAudioSource;


    void Awake(){
        get = this;
        // health = 3;
        // healthText.text = "Health : 3";
        // score = 0;
        // scoreText.text = "Score : 0";
    }

    // Start is called before the first frame update
    void Start(){
        Time.timeScale = 0;
        mainMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        gameOverAudioSource = GetComponent<AudioSource>();
        isPause = false;
        highscore = PlayerPrefs.GetInt(highscoreKey, 0);
        mainMenuHSTMP.text = "Highscore : " + highscore;

    }

    // Update is called once per frame
    void Update(){
        
    }

    public void zombieAttack(){
        //decrease health
        health--;
        if(health <= 0){
            healthText.text = "Game Over";
            GameOver();
        }else{
            healthText.text = "Health : " + health;

        }
    }

    public void increaseScore(){
        score++;
        scoreText.text = "Score : " + score;

    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame(){
        mainMenuPanel.SetActive(false);
        Time.timeScale = 1;
        health = 3;
        healthText.text = "Health : 3";
        score = 0;
        scoreText.text = "Score : 0";
        highscore = PlayerPrefs.GetInt(highscoreKey, 0);

    }

    public void GameOver(){
        if(score > highscore){
            highscore = score;
            PlayerPrefs.SetInt(highscoreKey, score);
            PlayerPrefs.Save();
        }
        gameOverPanel.SetActive(true);
        gameOverScoreTMP.text = "Score : " + score;
        gameOverHSTMP.text = "Highscore : " + highscore;
        Time.timeScale = 0;
        gameOverAudioSource.Play();
    }
    public void pauseResumeGame(){
        isPause = !isPause;
        if(isPause){
            Time.timeScale = 0;
            pauseButtonTMP.text = "Resume";
        }else{
            Time.timeScale = 1;
            pauseButtonTMP.text = "Pause";
        }
    }
    public void exitGame(){
        Application.Quit();
    }
}
