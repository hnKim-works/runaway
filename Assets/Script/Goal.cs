using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class Goal : MonoBehaviour
{
    private Boolean cleared;
    public GameObject panel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cleared = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoalIn() 
    {
        cleared=true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "Player" && cleared == true)
        {
            panel.GetComponent<FadeController>().Fade();
            StartCoroutine(Clear());
        }
    }

    IEnumerator Clear()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Stage2");

    }
}
