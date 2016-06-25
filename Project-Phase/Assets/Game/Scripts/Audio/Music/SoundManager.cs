using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public float volume = 1.0f;

	AudioSource audioSource;
	public AudioClip[] audioClips;

	void OnEnable() {
		audioSource = this.gameObject.GetComponent<AudioSource>();
		Events.onTabletPickedUpEvent += SetMusicPlay;
	}
	
	void OnDisable() {
		Events.onTabletPickedUpEvent -= SetMusicPlay;
	}

	void SetMusicPlay(bool toggle = false) {
		if (toggle) {
			audioSource.Play();
		} else {
			audioSource.Pause();
		}
	}

	void Update(){
		audioSource.volume = volume;
		if (audioClips.Length != 0){
			if (!audioSource.isPlaying) {
				playRandomTrack ();
			}
		}
	}
	
	public void playRandomTrack (){
		int randomIndex = Random.Range (0, audioClips.Length);
		audioSource.clip = audioClips [randomIndex];
		audioSource.Play ();
	}
}
