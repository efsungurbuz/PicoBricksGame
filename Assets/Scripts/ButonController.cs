using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButonController : MonoBehaviour
{
    public void PlaySampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void PlayGuideScene()
    {
        SceneManager.LoadScene("Guide");
    }
 
    public void PlayMainGuideScene()
    {
        SceneManager.LoadScene("MainGuide");
    }
    public void PlayGuideScene2()
    {
        SceneManager.LoadScene("Guide2");
    }
    public void PlayGuideScene3()
    {
        SceneManager.LoadScene("Guide3");
    }
    public void PlayGuideScene4()
    {
        SceneManager.LoadScene("Guide4");
    }
    /* For Guide one  */
    public void GameMenuSceneBack()
    {
        SceneManager.LoadScene("GameMenu");
    }
  
        /* For Guide two*/
     public void Guide2SceneBack()
    {
     SceneManager.LoadScene("Guide");
    }
    public void Guide3SceneBack()
    {
        
        SceneManager.LoadScene("Guide2");
        
    }
    public void Guide4SceneBack()
    {
        SceneManager.LoadScene("Guide3");
    }
    public void MainGuideSceneBack()
    {
        SceneManager.LoadScene("MainGuide");
    }
    public void OpenWebsite()
    {
        
        string websiteURL = "https://www.robotistan.com/sepet.xhtml";
        Application.OpenURL(websiteURL);
    }
 
}
