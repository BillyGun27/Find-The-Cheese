using UnityEngine;
using System.Collections;

public class PathGizmo : MonoBehaviour {
    public Transform[] Dir;
    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        for(int i=0; i<Dir.Length;i++)
        Gizmos.DrawCube(Dir[i].position, new Vector2(1, 1));
    }
}
