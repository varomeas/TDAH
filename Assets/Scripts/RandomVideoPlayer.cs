using UnityEngine;
using UnityEngine.Video;

public class RandomVideoPlayer : MonoBehaviour
{
    public VideoPlayer player;
    public VideoClip[] videoClips;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (videoClips.Length > 0 && player != null)
        {
            PlayRandomVid();
        }
        else
        {
            Debug.LogWarning("Le videoPLayer est vide ou la playlist aussi");
        }
    }

    void PlayRandomVid()
    {
        int randomIndex = Random.Range(0, videoClips.Length);

        player.clip = videoClips[randomIndex];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
