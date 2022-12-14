using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Doozy.Runtime.UIManager.Animators;


public class GameManager : MonoBehaviour{
    private string highscoreKey = "highscore";
    public static GameManager get;

    [Header("Mute Attributes")]
    public bool isMuted;
    public string isMuteKey = "IsMuted";


    [Header("Parameter HUD")]
    public int health = 3;
    public int extraHealth = 0;
    public UIContainerUIAnimator extraHealthPanelAnimator;
    public int score = 0;
    public int highscore = 0;

    [Header("Pause Attributes")]
    public TextMeshProUGUI pauseButtonTMP;
    public bool isPause = false;
    public UIContainerUIAnimator pausePanelAnimator;
    // public Sprite playIcon;
    public Sprite pauseIcon;
    [SerializeField] TextMeshProUGUI pauseScoreTMP;
    [SerializeField] TextMeshProUGUI pauseHSTMP;

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
    public UIContainerUIAnimator mainMenuPanelAnimator;
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
        // extraHealth = 0;
        mainMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        gameOverAudioSource = GetComponent<AudioSource>();
        isPause = false;
        highscore = PlayerPrefs.GetInt(highscoreKey, 0);
        mainMenuHSTMP.text = "Highscore : " + highscore;
        int muteStatus = PlayerPrefs.GetInt(isMuteKey, 0);

        if(muteStatus == 1){
            isMuted = true;
            AudioManager.ins.gameObject.SetActive(false);
        }else{
            isMuted = false;
            AudioManager.ins.gameObject.SetActive(true);
        }
        

    }

    // Update is called once per frame
    void Update(){
        
    }

    public void zombieAttack(){
        //decrease health
        health--;
        // if(health>0)
        AudioManager.ins.PlaySFX("alien_hit");
        // AudioManager.ins.playAlienHitSFX();
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
        if(score%10 == 0){
            increaseHealth();
        }

    }
    public void increaseHealth(){
        health++;
        // extraHealth++;
        extraHealthPanelAnimator.Show();
        extraHealthPanelAnimator.Hide();
        Debug.Log("Get Extra Life");
        healthText.text = "Health : " + health;
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame(){
        // mainMenuPanel.SetActive(false);
        Time.timeScale = 1;
        health = 3;
        healthText.text = "Health : 3";
        score = 0;
        scoreText.text = "Score : 0";
        highscore = PlayerPrefs.GetInt(highscoreKey, 0);
        // increaseHealth();

    }

    public void GameOver(){
        if(score > highscore){
            highscore = score;
            PlayerPrefs.SetInt(highscoreKey, score);
            PlayerPrefs.Save();
        }
        // AudioManager.ins.playGameOverSFX();
        AudioManager.ins.PlaySFX("game_over");
        gameOverPanel.SetActive(true);
        gameOverScoreTMP.text = "Score : " + score;
        gameOverHSTMP.text = "Highscore : " + highscore;
        Time.timeScale = 0;
        // gameOverAudioSource.Play();
    }
    public void pauseResumeGame(){
        isPause = !isPause;
        pauseScoreTMP.text = "Score : " + score;
        pauseHSTMP.text = "Highscore : " + highscore;
        if(isPause){
            Time.timeScale = 0;
            pauseButtonTMP.text = "Resume";
            pausePanelAnimator.Show();
            // pausePanelAnimator.gameObject.SetActive(true);

        }else{
            Time.timeScale = 1;
            pauseButtonTMP.text = "Pause";
            pausePanelAnimator.Hide();
        }
    }
    public void exitGame(){
        Application.Quit();
    }
    public void setMuteSound(){
        // if(isMute){
            
            isMuted = !isMuted;
            Debug.Log("Is muted : " + isMuted);
            AudioManager.ins.gameObject.SetActive(!isMuted);
            int muteStatus = isMuted ? 1 : 0 ;
            PlayerPrefs.SetInt(isMuteKey, muteStatus);
            PlayerPrefs.Save();
        // }
    }
}
