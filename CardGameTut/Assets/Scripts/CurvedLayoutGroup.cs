using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CurvedLayoutGroup : MonoBehaviour
{
    public bool updateWithInspectorValues;

    public float radius;
    public float angleDisplacement;
    public float maxArcChildAngle;
    public float maxArcAngle;

    public bool  reversed;

    [Range(-1,1)]
    public int alignment;

    new Transform transform;

    private Vector2 circleOrigin;
    private Vector2 displacementFromOrigin;
    private List<Vector2> childTargetDisplacements;
    private List<float> childTargetAngles;

    private float startAngle;
    private float dAngle;

    private int childCount;
    //private List<Transform> layoutChilds;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (transform == null) transform = GetComponent<Transform>();
        if (childTargetDisplacements == null) childTargetDisplacements = new List<Vector2>();
        if (childTargetAngles == null) childTargetAngles = new List<float>();
        //if (layoutChilds == null) layoutChilds = new List<Transform>();

        displacementFromOrigin = CreateVector(radius,angleDisplacement);
        circleOrigin = (Vector2)transform.position - displacementFromOrigin;

    }

    private void Update()
    {
        if (updateWithInspectorValues) Initialize();

        if(childCount != this.transform.childCount || updateWithInspectorValues)
        {
            circleOrigin = Vector3.zero;
            childCount = this.transform.childCount;
            UpdateChildTargetAngles();
            UpdateChildTargetDisplacements();

            Transform _child;

            for (int i = 0; i < childCount; i++)
            {

                _child = transform.GetChild(i);
                _child.localPosition = circleOrigin + childTargetDisplacements[i];
                _child.transform.localRotation= Quaternion.Euler(Vector3.forward * -childTargetAngles[i] * Mathf.Rad2Deg);
            }


        }
    }

    private void UpdateChildTargetAngles()
    {
        childTargetAngles.Clear();
        dAngle = -Mathf.Sign(maxArcChildAngle) * Mathf.Min(Mathf.Abs(maxArcChildAngle), Mathf.Abs(maxArcAngle / (childCount)));

        startAngle = (1 - alignment * 0.5f) * maxArcAngle - (0.5f + 0.5f * alignment) * dAngle * (childCount - 1) + angleDisplacement;

        for (int i = 0; i < childCount; i++)
        {
            childTargetAngles.Add((startAngle + i * dAngle) * Mathf.Deg2Rad);
        }
    }

    private void UpdateChildTargetDisplacements()
    {
        childTargetDisplacements.Clear();
        for (int i = 0; i < childCount; i++)
        {
            childTargetDisplacements.Add(CreateVector(radius,childTargetAngles[i]));
        }
    }

    private Vector2 CreateVector(float magnitude, float angle)
    {
        return new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)).normalized * magnitude;
    }
}
