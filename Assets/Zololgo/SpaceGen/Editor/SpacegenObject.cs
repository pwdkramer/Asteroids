using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

class SpacegenObject : MonoBehaviour {
	[MenuItem("GameObject/Create Other/Space Backdrop", false, -1)]
	static void MakeBackdrop () {

		string name = "Space Backdrop";
		GameObject GSO = new GameObject(name);
		Material mat_clouds = new Material (Shader.Find("SpaceGen/CloudsClusters_CG"));
		Material mat_stars = new Material (Shader.Find("SpaceGen/Stars_CG"));
		int count = 1;
		
		while (AssetDatabase.LoadAssetAtPath("Assets/SpaceGen/Materials/clouds"+count+".mat", typeof(Material))) {
		
			count++;
				
		}

		AssetDatabase.CreateAsset(mat_clouds, "Assets/SpaceGen/Materials/clouds"+count+".mat");
		AssetDatabase.CreateAsset(mat_stars, "Assets/SpaceGen/Materials/stars"+count+".mat");
		
		GSO.AddComponent(typeof(MeshFilter));
		GSO.AddComponent(typeof(MeshRenderer));
		MeshFilter gsoMF = GSO.GetComponent(typeof(MeshFilter)) as MeshFilter;
		gsoMF.mesh = Resources.Load("space_dome",typeof(Mesh)) as Mesh;
		var mats = new Material[2];
		mats[0] = mat_clouds;
		mats[1] = mat_stars;
		Renderer gsoRen = GSO.GetComponent(typeof(Renderer)) as Renderer;
		gsoRen.sharedMaterials = mats;
		GSO.AddComponent(typeof(SpaceBackdrop));
		Selection.activeObject = GSO;
		SpaceBackdrop gsoSB = GSO.GetComponent(typeof(SpaceBackdrop)) as SpaceBackdrop;
		gsoSB.Generate();
		 Undo.RegisterCreatedObjectUndo (GSO, "Create Space Backdrop object");
		
	}
}
