using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class esc : MonoBehaviour
{
    public Text Money;
    public Button ExitButton;
    public void clickexitButton()
    {
        Application.Quit();

    }
    public Button playButton;
    public void clickNewGameButton()
    {
        SceneManager.LoadScene("SampleScene");

    }
    public Button settingButton;
    public void clickSettingButton()
    {
        SceneManager.LoadScene("Settings");
    }
    bool active = true;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        active = !active;
        panel.SetActive(active);
    }
    public void updateScore(int score)
    {
        Money.text = $"{score}";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            active = !active;
            panel.SetActive(active);

        }
    }

    
}