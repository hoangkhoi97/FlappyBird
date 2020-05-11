using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameDialog : MonoBehaviour
{
    public static PauseGameDialog instance;

    [Header("GameUIEffect")]
    public Transform box;
    public GameObject btnFly;

    public List<Text> txts = new List<Text>();

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);


    }

    public void onShowUI()
    {
        foreach (Text txt in txts)
        {
            txt.transform.localScale = new Vector3(0, 0, 0);
            txt.color = new Color(1f, 1f, 1f, 1f);
        }
        btnFly.SetActive(false);
        GameController.instance.isPause = true;
        AwakeAnimation();
        AnimationShow();
    }

    private void AwakeAnimation()
    {
        box.gameObject.SetActive(true);
        box.position = new Vector3(this.transform.position.x, -1000f, this.transform.position.z);
    }

    private void AnimationShow()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(box.DOLocalMoveY(100f, 0.6f).SetDelay(0.1f).SetEase(Ease.OutQuad));
        seq.Append(box.DOLocalMoveY(0f, 0.2f));
    }

    public void onCloseUIPause()
    {
        Sequence seq = DOTween.Sequence();
        foreach(Text txt in txts)
        {
            seq.Append(txt.transform.DOScale(1f, 0.5f).OnComplete(()=> { txt.DOFade(0, 0.2f); }));
        
        }
       
        Invoke("Resume", 2f);
        box.DOLocalMoveY(-1000f, 0.6f).SetDelay(0.1f).SetEase(Ease.InQuad).OnComplete(()=> { box.gameObject.SetActive(false); });
    }

    private void Resume()
    {
        btnFly.SetActive(true);
        GameController.instance.isPause = false;
        bird.instance.BirdFly();

    }
}
