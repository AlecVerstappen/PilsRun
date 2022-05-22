using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UItutorial: MonoBehaviour
{
	public void ResetTutorial ()
    {
        SceneManager.LoadScene("tutorial");
    }
}
