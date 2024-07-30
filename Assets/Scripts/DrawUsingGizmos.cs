using UnityEngine;

[System.Serializable]
public class GizmoData
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
    public Color gizmoColor = Color.red;
}

public class DrawUsingGizmos : MonoBehaviour
{
    public GizmoData gizmoData = new GizmoData();

    public void SetGizmoData(Vector3 position, Vector3 rotation, Vector3 scale, Color color)
    {
        gizmoData.position = position;
        gizmoData.rotation = rotation;
        gizmoData.scale = scale;
        gizmoData.gizmoColor = color;
    }
    public void SetGizmoData(Vector3 position)
    {
        gizmoData.position = position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoData.gizmoColor;
        Gizmos.matrix = Matrix4x4.TRS(gizmoData.position, Quaternion.Euler(gizmoData.rotation), gizmoData.scale);
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        Gizmos.matrix = Matrix4x4.identity;
    }

}
