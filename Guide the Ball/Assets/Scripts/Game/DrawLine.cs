using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawLine : MonoBehaviour
{
    [SerializeField]
    private GameObject line;

    [SerializeField]
    [Range(0,1)]
    private float minUpdateDistance = 10;

    [SerializeField]
    private float maxDrawDistance;

    [SerializeField]
    private Slider slider;

    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private List<Vector2> linePoints;

    private float currentDrawDistance;
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
    /// Create line and set points
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

    /// <summary>
    /// Add new point to renderer and collider
    /// Updates Draw Distance
    /// </summary>
    /// <param name="newPoint"></param>
    private void UpdateLine(Vector2 newPoint)
    {
        linePoints.Add(newPoint);

        lineRenderer.positionCount++;
        int index = lineRenderer.positionCount - 1;

        currentDrawDistance += Vector2.Distance(lineRenderer.GetPosition(index - 1), lineRenderer.GetPosition(index));
        slider.value = 1 - (currentDrawDistance / maxDrawDistance);

        lineRenderer.SetPosition(index, newPoint);

        edgeCollider.points = linePoints.ToArray();

        if (currentDrawDistance >= maxDrawDistance)
        {
            canDraw = false;
        }
    }

    /// <summary>
    /// Toggles the ability to draw
    /// </summary>
    /// <param name="canDraw"></param>
    public void CanDraw(bool canDraw)
    {
        this.canDraw = canDraw;
    }
}
