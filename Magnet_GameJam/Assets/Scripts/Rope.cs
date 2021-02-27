using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform firstPoint;
    [SerializeField] private Transform secondPoint;

    private LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, firstPoint.position);
        lineRenderer.SetPosition(1, secondPoint.position);
    }
}
