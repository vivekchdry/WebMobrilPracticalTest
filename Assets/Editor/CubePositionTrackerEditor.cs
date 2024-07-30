using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Transform))]
public class CubePositionTrackerEditor : Editor
{
    private Vector3 previousPosition;
    private Transform cubeTransform;
    private DrawUsingGizmos drawUsingGizmos;

    private void OnEnable()
    {
        cubeTransform = (Transform)target;
        previousPosition = cubeTransform.position;

        if (cubeTransform.TryGetComponent<DrawUsingGizmos>(out DrawUsingGizmos out_DrawUsingGizmos))
        {
            drawUsingGizmos = out_DrawUsingGizmos;
        }
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (drawUsingGizmos == null)
        {
            return;
        }

        Vector3 changedPostion = drawUsingGizmos.gizmoData.position;

        if (cubeTransform.position != previousPosition)
        {

            if (previousPosition.x != cubeTransform.position.x)
            {
                changedPostion.x = cubeTransform.position.x;
            }
            if (previousPosition.y != cubeTransform.position.y)
            {
                changedPostion.y = cubeTransform.position.y;
            }
            if (previousPosition.z != cubeTransform.position.z)
            {
                changedPostion.z = cubeTransform.position.z;
            }

            previousPosition = cubeTransform.position;

        }

        drawUsingGizmos.SetGizmoData(changedPostion);

    }
}
