using UnityEngine;
using System.Collections;


public class SoundManager : MonoBehaviour {
	
	public AudioSource efxSource;                   
	public AudioSource musicSource;   
	public AudioSource loopSource;

	public AudioClip[] musicClips;
		
	public float lowPitchRange = .95f;             
	public float highPitchRange = 1.05f;            

	static SoundManager instance = null; 

	public static SoundManager Instance {
		get {
			return instance;
		}
	}

	void Awake () {

		musicSource.clip = musicClips[Random.Range (0, musicClips.Length)];
		musicSource.Play ();
		print (musicSource.clip.name);

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
	}

	public float MusicVolume {
		get{ 
			return musicSource.volume;
		}
		set {
			musicSource.volume = value;

			if (value > 1)
				musicSource.volume = 1;
			if (value < 0)
				musicSource.volume = 0;
			
		}
	}
	
	public void PlaySingle(AudioClip clip) {
		efxSource.clip = clip;

		efxSource.Play ();
	}

	public void PlayLoop(AudioClip clip) {
		
		loopSource.clip = clip;
		loopSource.Play ();

	}

	public void StopLoop() {
		loopSource.Stop ();
	}
	
	public void RandomizeSfx (params AudioClip[] clips) {
		
		int randomIndex = Random.Range(0, clips.Length);

		float randomPitch = Random.Range(lowPitchRange, highPitchRange);
		
		efxSource.pitch = randomPitch;

		efxSource.clip = clips[randomIndex];

		efxSource.Play();
	}
}


