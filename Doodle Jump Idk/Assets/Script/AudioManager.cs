using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip startClip;
    public AudioClip loopClip;
    void Start()
    {
        GetComponent<AudioSource>().loop = true;
        StartCoroutine(playEngineSound());
    }

    IEnumerator playEngineSound()
    {
        GetComponent<AudioSource>().clip = startClip;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        GetComponent<AudioSource>().clip = loopClip;
        GetComponent<AudioSource>().Play();
    }
}
