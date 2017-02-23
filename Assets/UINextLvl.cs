using UnityEngine;
using System.Collections;

public class UINextLvl : MonoBehaviour {

    public string levelName;

	public void LoadNextlevel()
    {
        Application.LoadLevel(levelName);
    }
}
