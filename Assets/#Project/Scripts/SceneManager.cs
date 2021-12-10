using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{

    // Start is called before the first frame update


    private void Update()
    {
        OnEscapePress();
    }

    public void OnEscapePress()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit");
            Application.Quit();

        }
    }
}
