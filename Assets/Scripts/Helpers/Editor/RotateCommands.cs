using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotateCommands
{
	[MenuItem("Tools/Rotate 90 degrees right")]
	public static void RotateObjectRight90()
	{
		Transform selectedGO = Selection.activeGameObject.transform;
		selectedGO.RotateAround(Tools.handlePosition,Vector3.up,90);
	}
	
	[MenuItem("Tools/Rotate 90 degrees left")]
	public static void RotateObjectLeft90()
	{
		Transform selectedGO = Selection.activeGameObject.transform;
		selectedGO.RotateAround(Tools.handlePosition,Vector3.up,-90);
	}

	[MenuItem("Tools/Move 10 units forward")]
	public static void MoveObject10UnitsForward()
	{
		Transform selectedGO = Selection.activeGameObject.transform;
		selectedGO.transform.position += Vector3.forward * 10;
	}
}
