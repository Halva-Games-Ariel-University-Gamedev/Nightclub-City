using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Tracks")]
    public AudioSource audioSource;
    public AudioClip popTrack;
    public AudioClip technoTrack;

    private AudioClip[] tracks;
    private int currentTrack = 0;

    void Awake()
    {
        // Singleton pattern
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


        tracks = new AudioClip[] { popTrack, technoTrack };


        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        PlayTrack(currentTrack);
    }

    public void PlayTrack(int index)
    {
        if (tracks.Length == 0) return;

        currentTrack = index % tracks.Length;
        audioSource.clip = tracks[currentTrack];
        audioSource.loop = true;
        audioSource.Play();
    }

    public void NextTrack()
    {
        currentTrack = (currentTrack + 1) % tracks.Length;
        PlayTrack(currentTrack);
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
