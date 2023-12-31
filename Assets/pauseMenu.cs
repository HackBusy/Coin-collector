using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] Button replay;
    [SerializeField] Button exit;
    [SerializeField] Text pauseText;
    private bool paused=false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(paused){
                Cursor.visible =false;
                Time.timeScale = 1f;
                replay.gameObject.SetActive(false);
                pauseText.gameObject.SetActive(false);
                exit.gameObject.SetActive(false); 
                paused=false;
            }else{
                replay.gameObject.SetActive(true);
                pauseText.gameObject.SetActive(true);
                exit.gameObject.SetActive(true); 
                Time.timeScale = 0f;
                Cursor.visible =true;
                paused=true;
            }
        }
    }
}
