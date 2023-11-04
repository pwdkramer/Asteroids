using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(SpaceBackdrop))]

public class SpaceBackdrop_UI : Editor {

	public bool optionsOpened = true;	

	void Awake() {
		
		SpaceBackdrop t = (SpaceBackdrop)target;
		t.SaveComponents();
	
	}

	public override void OnInspectorGUI() {
	
		SpaceBackdrop t = (SpaceBackdrop)target;
		GUI.changed = false;

		EditorGUILayout.Space();
		EditorGUILayout.Space();

		if(GUILayout.Button("Generate")){
			t.Generate(); 
		}

		EditorGUILayout.Space();

			EditorGUILayout.BeginHorizontal();

				EditorGUILayout.BeginVertical ();
				
					EditorGUILayout.LabelField("", GUILayout.Width(10), GUILayout.Height(21));	
					EditorGUILayout.LabelField("", GUILayout.Width(10), GUILayout.Height(21));	
					EditorGUILayout.LabelField("", GUILayout.Width(10), GUILayout.Height(21));	
					EditorGUILayout.LabelField("", GUILayout.Width(10), GUILayout.Height(21));	
					EditorGUILayout.LabelField("", GUILayout.Width(10), GUILayout.Height(21));	
					EditorGUILayout.LabelField("", GUILayout.Width(10), GUILayout.Height(21));	
					EditorGUILayout.LabelField("", GUILayout.Width(10), GUILayout.Height(21));	
								
				EditorGUILayout.EndVertical ();
				
				EditorGUILayout.BeginVertical ();
				
					t.enableSmallStars = EditorGUILayout.Toggle(t.enableSmallStars, GUILayout.Width(20), GUILayout.Height(21));
					t.enableBigStars = EditorGUILayout.Toggle(t.enableBigStars, GUILayout.Width(20), GUILayout.Height(21));
					t.enableTintStars = EditorGUILayout.Toggle(t.enableTintStars, GUILayout.Width(20), GUILayout.Height(21));
					t.enableGasclouds = EditorGUILayout.Toggle(t.enableGasclouds, GUILayout.Width(20), GUILayout.Height(21));
					t.enableClusters = EditorGUILayout.Toggle(t.enableClusters, GUILayout.Width(20), GUILayout.Height(21));
					t.enableTintClusters = EditorGUILayout.Toggle(t.enableTintClusters, GUILayout.Width(20), GUILayout.Height(21));
			
				EditorGUILayout.EndVertical ();
				
				EditorGUILayout.BeginVertical ();
				
					EditorGUILayout.LabelField("Small stars", GUILayout.Width(100), GUILayout.Height(21));	
					EditorGUILayout.LabelField("Big stars", GUILayout.Width(100), GUILayout.Height(21));	
					EditorGUILayout.LabelField("Stars' tint", GUILayout.Width(100), GUILayout.Height(21));	
					EditorGUILayout.LabelField("Gas clouds", GUILayout.Width(100), GUILayout.Height(21));	
					EditorGUILayout.LabelField("Clusters", GUILayout.Width(100), GUILayout.Height(21));	
					EditorGUILayout.LabelField("Clusters' tint", GUILayout.Width(100), GUILayout.Height(21));	
								
				EditorGUILayout.EndVertical ();
				EditorGUILayout.BeginVertical ();
				
					if(GUILayout.Button("Randomize", GUILayout.Width(80), GUILayout.Height(20))){t.RandomizeSmallStars();}
					if(GUILayout.Button("Randomize", GUILayout.Width(80), GUILayout.Height(20))){t.RandomizeBigStars();}
					if(GUILayout.Button("Randomize", GUILayout.Width(80), GUILayout.Height(20))){t.RandomizeStarsTint();}
					if(GUILayout.Button("Randomize", GUILayout.Width(80), GUILayout.Height(20))){
						t.RandomizeClouds();
						t.RandomizeCloudsTint();
					}
					if(GUILayout.Button("Randomize", GUILayout.Width(80), GUILayout.Height(20))){t.RandomizeClusters();}
					if(GUILayout.Button("Randomize", GUILayout.Width(80), GUILayout.Height(20))){t.RandomizeClustersTint();}
								
				EditorGUILayout.EndVertical ();

			EditorGUILayout.EndHorizontal ();
			
			t.SwitchOffComponents();

		if (GUI.changed) {
		
			EditorUtility.SetDirty(t);
			//Undo.RegisterSceneUndo("SpaceGen changes");
		
		}

	}

	void OnSceneGUI(){

		SpaceBackdrop t = (SpaceBackdrop)target;
		Handles.BeginGUI();
		var tempColor1 = GUI.color;
		var tempColor2 = GUI.contentColor;

			for (var gbox = 0; gbox<15; gbox++){
				GUI.Box(new Rect(Screen.width - 220, Screen.height - 200, 210, 155),"");
			}

			GUILayout.BeginArea(new Rect(Screen.width - 210, Screen.height - 190, 200, 180));

				GUI.color = new Color(1,1,1,1);
				GUI.contentColor = new Color(0,0,0,1);

		EditorGUILayout.BeginHorizontal();

			EditorGUILayout.BeginVertical ();
			
				EditorGUILayout.LabelField("Small stars", GUILayout.Width(100), GUILayout.Height(21));	
				EditorGUILayout.LabelField("Big stars", GUILayout.Width(100), GUILayout.Height(21));	
				EditorGUILayout.LabelField("Stars' tint", GUILayout.Width(100), GUILayout.Height(21));	
				EditorGUILayout.LabelField("Gas clouds", GUILayout.Width(100), GUILayout.Height(21));	
				EditorGUILayout.LabelField("Clusters", GUILayout.Width(100), GUILayout.Height(21));	
				EditorGUILayout.LabelField("Clusters' tint", GUILayout.Width(100), GUILayout.Height(21));	
							
			EditorGUILayout.EndVertical ();
			EditorGUILayout.BeginVertical ();

				GUI.color = new Color(1,1,1,1);
				GUI.contentColor = new Color(1,1,1,1);

				if(GUILayout.Button("Randomize", GUILayout.Width(80), GUILayout.Height(20))){t.RandomizeSmallStars();}
				if(GUILayout.Button("Randomize", GUILayout.Width(80), GUILayout.Height(20))){t.RandomizeBigStars();}
				if(GUILayout.Button("Randomize", GUILayout.Width(80), GUILayout.Height(20))){t.RandomizeStarsTint();}
				if(GUILayout.Button("Randomize", GUILayout.Width(80), GUILayout.Height(20))){
					t.RandomizeClouds();
					t.RandomizeCloudsTint();
				}
				if(GUILayout.Button("Randomize", GUILayout.Width(80), GUILayout.Height(20))){t.RandomizeClusters();}
				if(GUILayout.Button("Randomize", GUILayout.Width(80), GUILayout.Height(20))){t.RandomizeClustersTint();}
							
			EditorGUILayout.EndVertical ();

		EditorGUILayout.EndHorizontal ();
			
			GUILayout.EndArea();
				
		Handles.EndGUI();
		
	}

}

/*
var enableSmallStars : boolean = true;
var enableBigStars : boolean = true;
var enableClusters : boolean = true;
var enableGasclouds : boolean = true;
var enableTintStars : boolean = true;
var enableTintClusters : boolean = true;
var enableTintGasclouds : boolean = true;
//*/