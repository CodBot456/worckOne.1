using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
  
    public Button playButton;
    public void clickPlayButton()
    {
        SceneManager.LoadScene("SampleScene");

    }
    public Button settingButton;
    public void clickSettingButton()
    {
        SceneManager.LoadScene("Settings");
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
