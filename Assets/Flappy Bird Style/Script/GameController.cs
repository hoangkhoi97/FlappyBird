using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;          
    public Text scoreText;                       
    public GameOverDialog gameOverDialog;
    public AudioClip audioDie;
    private AudioSource sourceAudio;

    public Button btnPause;

    public int score = 0;   

    public bool gameOver = false;
    public bool isPause = true;
    //

    //  public Button btnRestart;
    //first scene
    public bool firstscene = false;


    void Awake()
    {    
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        if(!firstscene)
        {
            GameReadyDialog.instance.onShowUI();
        }
        sourceAudio = GetComponent<AudioSource>();  
    }

    public void BirdScored()
    {
        if (gameOver)
            return;
        score++;
        scoreText.text = score.ToString();
    }


    public void BirdDied()
    {
        sourceAudio.Stop();

        Invoke("SoundDie", 0.25f);
       
        scoreText.gameObject.SetActive(false);
        gameOver = true;
        gameOverDialog.gameObject.SetActive(true);
        btnPause.gameObject.SetActive(false);
        gameOverDialog.onShowUI();
    }
    private void SoundDie()
    {
        sourceAudio.PlayOneShot(audioDie, 0.6f);
    }

    [ContextMenu("clear")]
    public void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
}
