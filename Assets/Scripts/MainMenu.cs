using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play ()
    {
        SceneManager.LoadScene("level1");
    }
	
	public void Tutorial ()
    {
        SceneManager.LoadScene("tutorial");
    }
	
	public void Quit ()
    {
        Application.Quit();
    }
}
