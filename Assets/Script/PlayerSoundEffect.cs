using UnityEngine;
using UnityEngine.Audio;

public class PlayerSoundEffect : MonoBehaviour
{
    public AudioClip damageAudioSource;
    public AudioClip getAudioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyDamage()
    {
        GetComponent<AudioSource>().PlayOneShot(damageAudioSource);
    }
    void CatchPepero()
    {
        GetComponent<AudioSource>().PlayOneShot(getAudioSource);
    }

}
