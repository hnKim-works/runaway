using System.Collections;
using UnityEngine;

public class TitleSound1 : MonoBehaviour
{
    public AudioClip witchAudioSource;
    public AudioClip cryAudioSource;

    private bool canLaugh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canLaugh = false;
        StartCoroutine(WitchLaugh(1.0f));
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
        
    IEnumerator WitchLaugh(float time)
    {
        canLaugh = true;
        yield return new WaitForSeconds(time);
        GetComponent<AudioSource>().PlayOneShot(witchAudioSource);
        yield return new WaitForSeconds(2.5f);
        GetComponent<AudioSource>().PlayOneShot(cryAudioSource);
    }
}
