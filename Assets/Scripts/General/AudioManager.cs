using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [Header("Audio Source")]
   [SerializeField] AudioSource playerSound;
   [SerializeField] AudioSource enemySound;
   [SerializeField] AudioSource backgroundSound;

   [Header("Audio Clips")]
   public AudioClip ambience;
   public AudioClip dash;
   public AudioClip playerhurt;
   public AudioClip playerdeath;
   public AudioClip whisperhurt;
   public AudioClip whispershoot;   
   public AudioClip whispervoice;
   public AudioClip whisperdeath;

    private void Start()
   {
      backgroundSound.Play();
   }

   public void PlaySfx(AudioClip clip)
   {
      enemySound.PlayOneShot(clip);
      playerSound.PlayOneShot(clip);
    }
}
