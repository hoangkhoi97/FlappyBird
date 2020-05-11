using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnScore : MonoBehaviour
{
    public AudioClip audioScore;
    private AudioSource sourceAudio;

    private void Start()
    {
        sourceAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<bird>() != null)
        {
            sourceAudio.PlayOneShot(audioScore, 0.6f);
            GameController.instance.BirdScored();
        }
    }
}
