using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField]
    private GameObject line;

    [SerializeField]
    [Range(0,1)]
    private float minUpdateDistance;

    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private List<Vector2> linePoints;

    private bool canDraw = true;

    private void Awake()
    {
        linePoints = new List<Vector2>();
    }

    /// <summary>
    /// Input
    /// </summary>
    void Update()
    {
        if (canDraw)
        {
            //Left Click
            if (Input.GetMouseButtonDown(0))
            {
                CreateLine();
            }

            //Hold Left Click
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(mousePosition, linePoints[linePoints.Count - 1]) > minUpdateDistance)
                {
                    UpdateLine(mousePosition);
                }
            }
        }
    }

    /// <summary>
    /// Create line and set points.
    /// </summary>
    private void CreateLine()
    {
        GameObject currentLine = Instantiate(line, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();

        linePoints.Clear();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        linePoints.Add(mousePosition);
        linePoints.Add(mousePosition);

        lineRenderer.SetPosition(0, linePoints[0]);
        lineRenderer.SetPosition(1, linePoints[1]);

        edgeCollider.points = linePoints.ToArray();
    }


    private void UpdateLine(Vector2 newPoint)
    {
        linePoints.Add(newPoint);

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPoint);

        edgeCollider.points = linePoints.ToArray();
    }

    public void CanDraw(bool canDraw)
    {
        this.canDraw = canDraw;
    }
}
