using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private static SoundManager _instance = null;
	public static SoundManager getInstance() {
		return _instance;
	}

	public AudioSource musicSource;
	public AudioSource sfxSource;


	public AudioClip sfxSthoot;

	void Awake(){
		if (_instance != null && _instance != this) {
			Destroy (this.gameObject);
			return;
		}

		_instance = this;
	}

	void Start(){
		DontDestroyOnLoad (this.gameObject);
	}

	public void Play(AudioClip clip, AudioSource source, bool loop){
		source.clip = clip;
		source.loop = loop;
		source.Play ();
	}

}
