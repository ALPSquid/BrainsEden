using UnityEngine;
using System.Collections;

public class SFXManager : MonoBehaviour {

	public float volume = 0.2f;
	public AudioClip[] audioClips;
	AudioSource sfxSource;

	void Start() {
		sfxSource = this.gameObject.GetComponent<AudioSource>();
		sfxSource.loop = true;
	}

	public void playSingleSFX(AudioClip clip){
		sfxSource.clip = clip;
		sfxSource.Play ();
	}
	
	public void playRandomSFX (params AudioClip[] sfx){
		int randomIndex = Random.Range (0, sfx.Length);
		sfxSource.clip = sfx [randomIndex];
		sfxSource.Play ();
	}

	public void StartSFX(){
		if (!sfxSource.isPlaying){
			sfxSource.Play();
		}
	}

	public void StopSFX(){
		if (sfxSource.isPlaying){
			sfxSource.Pause();
		}
	}
}
