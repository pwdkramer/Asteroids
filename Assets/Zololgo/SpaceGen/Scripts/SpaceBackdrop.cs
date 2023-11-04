using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpaceBackdrop : MonoBehaviour {
	// constants
	string starssparsePath = "Textures/StarsSparse/starssparse";
	string starsdensePath = "Textures/StarsDense/starsdense";
	string gascloudsPath = "Textures/Gasclouds/gascloud";
	string clustersPath = "Textures/Clusters/cluster";

	// switches
	public bool enableSmallStars = true;
	public bool enableBigStars = true;
	public bool enableClusters = true;
	public bool enableGasclouds = true;
	public bool enableTintStars = true;
	public bool enableTintClusters = true;
	public bool enableTintGasclouds = true;

	//temps
	Texture2D smallStarsTexture;
	Texture2D bigStarsTexture;
	Color starsColor;
	Color gasCloudsColor;
	Color clustersColor;

	// hide unnecessaries
	void OnEnable(){
		//*
		gameObject.GetComponent<Renderer>().hideFlags = HideFlags.HideInInspector;
		gameObject.GetComponent<MeshFilter>().hideFlags = HideFlags.HideInInspector;
		GetComponent<Renderer>().sharedMaterials[0].hideFlags = HideFlags.HideInInspector;
		GetComponent<Renderer>().sharedMaterials[1].hideFlags = HideFlags.HideInInspector;
		//*/
	}

	// show hided components when disable/remove, to avoid 'leaks'
	void OnDisable(){
		//*
		gameObject.GetComponent<Renderer>().hideFlags = 0;
		gameObject.GetComponent<MeshFilter>().hideFlags = 0;
		GetComponent<Renderer>().sharedMaterials[0].hideFlags = 0;
		GetComponent<Renderer>().sharedMaterials[1].hideFlags = 0;
		//*/
	}

	public void Generate() {

		if (enableSmallStars)
			RandomizeSmallStars();
			
		if (enableBigStars)
			RandomizeBigStars();
		
		if (enableTintStars)		
			RandomizeStarsTint();
			
		if (enableGasclouds)
			RandomizeClouds();
			
		if (enableTintGasclouds)
			RandomizeCloudsTint();
			
		if (enableClusters)
			RandomizeClusters();
		
		if (enableTintClusters)
			RandomizeClustersTint();
	}

	public void RandomizeSmallStars() {

		int rnd = Random.Range(1,16);
		var tex	= Resources.Load(starssparsePath+rnd) as Texture2D;
		smallStarsTexture = tex;
		GetComponent<Renderer>().sharedMaterials[1].SetTexture("_Stars1", tex);
		Vector2 scale;
		scale.x = Random.Range(20.0f,30.0f);
		scale.y = scale.x;
		GetComponent<Renderer>().sharedMaterials[1].SetTextureScale ("_Stars1", scale);
		
	}

	public void RandomizeBigStars() {

		int rnd = Random.Range(1,16);
		Texture2D tex	= Resources.Load(starssparsePath+rnd) as Texture2D;
		bigStarsTexture = tex;
		GetComponent<Renderer>().sharedMaterials[1].SetTexture("_Stars2", tex);
		Vector2 scale;
		scale.x = Random.Range(7.0f,9.0f);
		scale.y = scale.x;
		GetComponent<Renderer>().sharedMaterials[1].SetTextureScale ("_Stars2", scale);
		
	}

	public void RandomizeStarsTint() {

		starsColor = RandomizeTint(0.5f, 1.0f, 0.5f, 1.0f, 2.0f);
		GetComponent<Renderer>().sharedMaterials[1].SetColor("_Tint", starsColor);

	}

	public void RandomizeCloudsTint() {

		gasCloudsColor = RandomizeTint(0.0f, 1.0f, 1.0f, 0.15f, 0.35f);
		GetComponent<Renderer>().sharedMaterials[0].SetColor("_Tint1", gasCloudsColor);

	}

	public void RandomizeClustersTint() {

		clustersColor = RandomizeTint(0.0f, 1.0f, 1.0f, 1.0f, 2.0f);
		GetComponent<Renderer>().sharedMaterials[0].SetColor("_Tint2", clustersColor);

	}

	public void RandomizeClouds() {

		int rnd;
		Texture2D tex;
		rnd = Random.Range(1,11);
		tex = Resources.Load(gascloudsPath+rnd) as Texture2D;
		GetComponent<Renderer>().sharedMaterials[0].SetTexture("_Cloud1", tex);
		rnd = Random.Range(1,11);
		tex = Resources.Load(gascloudsPath+rnd) as Texture2D;
		GetComponent<Renderer>().sharedMaterials[0].SetTexture("_Cloud2", tex);

	}

	public void RandomizeClusters() {

		int rnd;
		Texture2D tex; 
		
		rnd = Random.Range(0,11);
		tex = Resources.Load(clustersPath+rnd) as Texture2D;
		GetComponent<Renderer>().sharedMaterials[0].SetTexture("_ClusterMask", tex);

		rnd = Random.Range(0,11);
		tex = Resources.Load(clustersPath+rnd) as Texture2D;
		GetComponent<Renderer>().sharedMaterials[0].SetTexture("_ClusterMask2", tex);

		rnd = Random.Range(1,16);
		tex = Resources.Load(starsdensePath+rnd) as Texture2D;
		GetComponent<Renderer>().sharedMaterials[0].SetTexture("_Stars", tex);

		Vector2 scale;
		scale.x = Random.Range(3.0f,4.5f);
		scale.y = scale.x;
		GetComponent<Renderer>().sharedMaterials[0].SetTextureScale ("_Stars", scale);
		
	}

	public Color RandomizeTint(float min, float max, float mul, float s1, float s2) {

		Color tint = new Color();
		int rnd;
		rnd = Random.Range(0,6);
		
		if (rnd == 0 ) {
		
			tint.r = min;
			tint.g = max;
			tint.b = Random.value*mul+(1-mul);
			
		}
		else if (rnd == 1 ) {
		
			tint.r = max;
			tint.g = min;
			tint.b = Random.value*mul+(1-mul);
			
		}
		else if (rnd == 2 ) {
		
			tint.r = min;
			tint.g = Random.value*mul+(1-mul);
			tint.b = max;
			
		}
		else if (rnd == 3 ) {
		
			tint.r = max;
			tint.g = Random.value*mul+(1-mul);
			tint.b = min;
			
		}
		else if (rnd == 4 ) {
		
			tint.r = Random.value*mul+(1-mul);
			tint.g = min;
			tint.b = max;
			
		}
		else if (rnd == 5 ) {
		
			tint.r = Random.value*mul+(1-mul);
			tint.g = max;
			tint.b = min;
			
		}

		var m = Random.Range(s1, s2);
		tint.r = Mathf.Min(1, tint.r * m);
		tint.g = Mathf.Min(1, tint.g * m);
		tint.b = Mathf.Min(1, tint.b * m);
		return tint;

	}

	public void SwitchOffComponents() {

		Texture2D tex;
		Color col;

	//-------------------------------------------------------------------------------
		if (!enableSmallStars) {
			tex = Resources.Load(starssparsePath+"null") as Texture2D;
			GetComponent<Renderer>().sharedMaterials[1].SetTexture("_Stars1", tex);
		}
		else {
			GetComponent<Renderer>().sharedMaterials[1].SetTexture("_Stars1", smallStarsTexture);
		}

	//-------------------------------------------------------------------------------
		if (!enableBigStars) {
			tex = Resources.Load(starssparsePath+"null") as Texture2D;
			GetComponent<Renderer>().sharedMaterials[1].SetTexture("_Stars2", tex);
		}
		else {
			GetComponent<Renderer>().sharedMaterials[1].SetTexture("_Stars2", bigStarsTexture);
		}

	//-------------------------------------------------------------------------------
		if (!enableTintStars) {
			col = new Color (1,1,1);
			GetComponent<Renderer>().sharedMaterials[1].SetColor("_Tint", col);
		}
		else {
			GetComponent<Renderer>().sharedMaterials[1].SetColor("_Tint", starsColor);
		}

	//-------------------------------------------------------------------------------
		if (!enableGasclouds) {
			col = new Color (0,0,0);
			GetComponent<Renderer>().sharedMaterials[0].SetColor("_Tint1", col);
		}
		else {
			GetComponent<Renderer>().sharedMaterials[0].SetColor("_Tint1", gasCloudsColor);
		}
	//-------------------------------------------------------------------------------
		if (!enableTintGasclouds) {
			col = new Color (0.5f,0.5f,0.5f);
			//renderer.sharedMaterials[0].SetColor("_Tint1", col);
		}
		else {
			//renderer.sharedMaterials[0].SetColor("_Tint1", gasCloudsColor);
		}
	//-------------------------------------------------------------------------------
		if (!enableClusters) {
			col = new Color (0,0,0);
			GetComponent<Renderer>().sharedMaterials[0].SetColor("_Tint2", col);
		}
		else {
			GetComponent<Renderer>().sharedMaterials[0].SetColor("_Tint2", clustersColor);
		}
	//-------------------------------------------------------------------------------
		if (!enableTintClusters && enableClusters) {
			col = new Color (1,1,1);
			GetComponent<Renderer>().sharedMaterials[0].SetColor("_Tint2", col);
		}
		else if (enableClusters) {
			GetComponent<Renderer>().sharedMaterials[0].SetColor("_Tint2", clustersColor);
		}
	//-------------------------------------------------------------------------------

	}

	public void SaveComponents() {
 
			smallStarsTexture = (Texture2D)GetComponent<Renderer>().sharedMaterials[1].GetTexture("_Stars1");
			bigStarsTexture = (Texture2D)GetComponent<Renderer>().sharedMaterials[1].GetTexture("_Stars2");
			starsColor = GetComponent<Renderer>().sharedMaterials[1].GetColor("_Tint");
			gasCloudsColor = GetComponent<Renderer>().sharedMaterials[0].GetColor("_Tint1");
			clustersColor = GetComponent<Renderer>().sharedMaterials[0].GetColor("_Tint2");
			
	}
}