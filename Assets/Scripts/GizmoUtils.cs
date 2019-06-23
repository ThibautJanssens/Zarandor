using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoUtils : MonoBehaviour {

    public static void DrawRect(Rect rect, Color col){
        Gizmos.color = col;
        Gizmos.DrawLine(rect.min, new Vector3(rect.xMin, rect.yMax));
        Gizmos.DrawLine(new Vector3(rect.xMin, rect.yMax), rect.max);
        Gizmos.DrawLine(rect.max, new Vector3(rect.xMax, rect.yMin));
        Gizmos.DrawLine(new Vector3(rect.xMax, rect.yMin), rect.min);
    }
}
