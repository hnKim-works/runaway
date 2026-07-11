using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeController : MonoBehaviour
{
    private Image panel;
    float time = 0.0f;
    float fadeTime = 1.0f;
    private void Awake()
    {
        panel = GetComponent<Image>();
    }

    public void Fade()
    {
        StartCoroutine(FadeOut());
    }



   IEnumerator FadeOut()
    {
        panel.gameObject.SetActive(true);
        Color color = panel.color;

        while (color.a < 1)
        {
            time += Time.deltaTime / fadeTime;
            color.a = Mathf.Lerp(0,1,time);
            panel.color = color;
           
            yield return null;  

        }
 
    }

  
}
