﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(RoomScript))]
public class RoomScriptInspector : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        RoomScript room = (RoomScript)target;
        if (GUILayout.Button("Generate!"))
        {
            Transform walls = room.transform.Find("Walls");
            if (walls) DestroyImmediate(walls.gameObject);

            walls = (new GameObject("Walls")).transform;
            walls.SetParent(room.transform);
            walls.localPosition = new Vector3(0, 0, 0);

            // Floor
            GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Quad);
            floor.name = "Floor";
            floor.transform.SetParent(walls);
            floor.transform.localPosition = new Vector3(room.width / 2f, 0, room.depth / 2f);
            floor.transform.localScale = new Vector3(room.width, room.depth, 1);
            floor.transform.Rotate(new Vector3(90, 0, 0));

            // Ceiling
            GameObject ceiling = GameObject.CreatePrimitive(PrimitiveType.Quad);
            ceiling.name = "Ceiling";
            ceiling.transform.SetParent(walls);
            ceiling.transform.localPosition = new Vector3(room.width / 2f, room.height, room.depth / 2f);
            ceiling.transform.localScale = new Vector3(room.width, room.depth, 1);
            ceiling.transform.Rotate(new Vector3(-90, 0, 0));

            // BackWall
            GameObject backWall = GameObject.CreatePrimitive(PrimitiveType.Quad);
            backWall.name = "BackWall";
            backWall.transform.SetParent(walls);
            backWall.transform.localPosition = new Vector3(room.width / 2f, room.height / 2f, room.depth);
            backWall.transform.localScale = new Vector3(room.width, room.height, 1);

            // LeftWall
            GameObject leftWall = GameObject.CreatePrimitive(PrimitiveType.Quad);
            leftWall.name = "LeftWall";
            leftWall.transform.SetParent(walls);
            leftWall.transform.localPosition = new Vector3(0, room.height / 2f, room.depth / 2f);
            leftWall.transform.localScale = new Vector3(room.depth, room.height, 1);
            leftWall.transform.Rotate(new Vector3(0, -90, 0));

            // RightWall
            GameObject rightWall = GameObject.CreatePrimitive(PrimitiveType.Quad);
            rightWall.name = "RightWall";
            rightWall.transform.SetParent(walls);
            rightWall.transform.localPosition = new Vector3(room.width, room.height / 2f, room.depth / 2f);
            rightWall.transform.localScale = new Vector3(room.depth, room.height, 1);
            rightWall.transform.Rotate(new Vector3(0, 90, 0));
        }
    }
}
