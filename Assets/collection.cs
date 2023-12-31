using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collection : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text OverText;
    [SerializeField] Text WonText;
    [SerializeField] Text hintText;
    [SerializeField] Button replay;
    [SerializeField] Button exit;
    [SerializeField] RawImage background;
    [SerializeField] int maxScore;
    public int score=0;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "collectable"){
            collision.gameObject.SetActive(false);
            score+=1;
            scoreText.text = "Score: "+score;
        }
        if (collision.gameObject.tag == "End"){
            if(score<maxScore){
                hintText.gameObject.SetActive(true);
            }else{
                collision.gameObject.SetActive(false);
                Time.timeScale = 0f;
                WonText.gameObject.SetActive(true);
                replay.gameObject.SetActive(true);
                exit.gameObject.SetActive(true);
                background.gameObject.SetActive(true);
                Cursor.visible =true;
            }
        }
        if (collision.gameObject.tag == "Death"){
            OverText.gameObject.SetActive(true);
            replay.gameObject.SetActive(true);
            exit.gameObject.SetActive(true);
            background.gameObject.SetActive(true);
            Cursor.visible =true;
            Time.timeScale = 0f;
        }
    }

    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "End"){
            hintText.gameObject.SetActive(false);
        }
    }
}
