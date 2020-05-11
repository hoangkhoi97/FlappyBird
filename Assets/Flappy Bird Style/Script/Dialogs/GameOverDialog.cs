using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverDialog : MonoBehaviour
{
    public static GameOverDialog instance;

    [Header("GameUIEffect")]
    public Transform title;
    public Transform box;
    public List<Button> btns = new List<Button>();

    [Header("GameUILoad")]
    public Image medalSilver;
    public Image medalGold;
    public Text score, bestscore;
    public int best=0, newScore=0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }


    public void onShowUI()
    {
        AwakeAnimation();
        AnimationShow();
    }

    private void AwakeAnimation()
    {
        title.localScale = new Vector3(0, 0, 0);
        box.position = new Vector3(this.transform.position.x,-1000f, this.transform.position.z);
        foreach (Button btn in btns)
        {
            btn.transform.localScale = new Vector3(0, 0, 0);
        }

        newScore = GameController.instance.score;
        //for(int i = 0; i<=newScore;i++)
        //{
        //    score.text = i.ToString();
        //}
        score.text = newScore.ToString();
        //nap best score

        if (PlayerPrefs.GetInt("BestScore").ToString() == null) 
        {
            bestscore.text = newScore.ToString();
            PlayerPrefs.SetInt("BestScore", newScore);
        }
        else
        {
            best = PlayerPrefs.GetInt("BestScore");
            if(newScore>best)
            {
                best = newScore;
               
                PlayerPrefs.SetInt("BestScore", newScore);
            }
            bestscore.text = best.ToString();
        }
    }

    private void AnimationShow()
    {
        Sequence seq = DOTween.Sequence();
        title.DOScale(new Vector3(1f, 1f, 1f), 0.3f).SetDelay(0.1f).OnComplete(() => { title.DOPunchRotation(new Vector3(1f,1f,1f),1f,1,1); });
        seq.Append(box.DOLocalMoveY(100f,0.6f).SetDelay(0.1f).SetEase(Ease.InQuad));
        seq.Append(box.DOLocalMoveY(0f, 0.2f));
        foreach (Button btn in btns)
        {
            btn.transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f).SetDelay(1f);
        }
    }

    public void onCloseUI()
    {

    }
}
