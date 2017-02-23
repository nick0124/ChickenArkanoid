using UnityEngine;
using System.Collections;

public class UITryAgin : MonoBehaviour {

    public string levelName;

    public void TryAgin()
    {
        Application.LoadLevel(levelName);
    }
}
