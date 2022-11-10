using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;//引入命名空间
using TMPro;

public class loadmanager : MonoBehaviour
{
    public GameObject loadScreen;
    public Slider slider;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI waiting;

    public void Start(){
    //  public void LoadNextLevel(){
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel(){
        loadScreen.SetActive(true);
        AsyncOperation operation =SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        
        operation.allowSceneActivation=false;
        //
        slider.value=0;
        int i=100;
        float change=0.01F;
        while(i>=0){
            Thread.Sleep(100);
            if((i/10)%2==0)waiting.text="Waiting......";
            else waiting.text="Nearly ready, Waiting......";
            slider.value+=change;
            Text.text=(int)(slider.value*100)+" %";
            i-=1;
            yield return null;
        }  
        operation.allowSceneActivation=true; 

    }
}
