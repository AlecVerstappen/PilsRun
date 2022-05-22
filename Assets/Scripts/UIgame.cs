using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIgame: MonoBehaviour
{
	public void ResetGame ()
    {
        SceneManager.LoadScene("level1");
    }
	public void menu ()
    {
        SceneManager.LoadScene("menu");
    }
}
