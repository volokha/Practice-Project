using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds;			
	private float[] parallaxScales;	

	public float smoothing = 1f;			

	private Transform cam;					

	void Start () {
		
		parallaxScales = new float[backgrounds.Length];

		for (int i = 0; i < backgrounds.Length; i++) {
			
			parallaxScales[i] = i;

		}
	}
		
	void Update () {

		for (int i = 0; i < backgrounds.Length; i++) {
			
			float backgroundWithParallax = backgrounds[i].position.x + parallaxScales[i] * (-0.2f) * smoothing;

			Vector3 backgroundNextPosition = new Vector3 (backgroundWithParallax, backgrounds[i].position.y, backgrounds[i].position.z);

			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundNextPosition, Time.deltaTime);

		}



	}
}
