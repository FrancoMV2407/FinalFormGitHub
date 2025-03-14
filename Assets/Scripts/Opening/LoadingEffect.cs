using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingEffect : MonoBehaviour
{
    public float loadingTime;
    public AudioSource intermission1;
    public AudioSource intermission2;
    public string nextScene;

    private void Awake()
    {
        PlayAudio();  
    }
    private void Start()
    {
        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(loadingTime);
        SceneManager.LoadScene(nextScene);
    }

    private void PlayAudio()
    {
        AudioSource selectedAudio = UnityEngine.Random.Range(0f, 1f) > 0.5f ? intermission1 : intermission2;
        selectedAudio.Play();
    }
}



