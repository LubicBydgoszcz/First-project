using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackPlayer : MonoBehaviour
{
    public AudioClip[] SoundTracks;
    AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(AS.isPlaying == false)
        {
            AS.clip = SoundTracks[Random.Range(0, SoundTracks.Length - 1)];

            AS.Play();
        }
    }
}
