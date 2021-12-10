using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeBG : MonoBehaviour
{
    public GameObject welcomeBG;
    public float timer = 3f;
    void Start()
    {
       

    }

    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0) { welcomeBG.gameObject.transform.localScale += new Vector3(0, 0, 0); }

    }
}
