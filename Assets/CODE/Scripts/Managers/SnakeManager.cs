using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeManager : MonoBehaviour
{
    public int currentValue = 1;
    public int followDistance;
    public GameObject segmentPrefab;
    public List<Transform> nodes = new List<Transform>();

    public TextMeshPro headText;

    private List<Vector3> positionsHistory = new List<Vector3>();

    void Start()
    {
        UpdateHeadText();
    }

    void Update()
    {
        positionsHistory.Insert(0, transform.position);

        // Limit history size to prevent memory leak
        int maxHistory = (nodes.Count + 1) * followDistance + 1;
        if (positionsHistory.Count > maxHistory)
        {
            positionsHistory.RemoveRange(maxHistory, positionsHistory.Count - maxHistory);
        }

        Movenodes();
    }

    public void AddNumber(int value)
    {  
        // Add value to current value
        currentValue += value;
        UpdateHeadText();
        RebuildSnake();
    }

    void UpdateHeadText()
    {
        headText.text = currentValue.ToString();
    }

    void RebuildSnake()
    {
        foreach (Transform seg in nodes)
            Destroy(seg.gameObject);

        nodes.Clear();

        for (int i = currentValue - 1; i >= 1; i--)
        {
            GameObject newSeg = Instantiate(segmentPrefab);   // Create new segment
            newSeg.GetComponentInChildren<TextMeshPro>().text = i.ToString();   // Set text of new nodes
            nodes.Add(newSeg.transform);    // Add new nodes to list
        }
    }

void Movenodes()
{
    for (int i = 0; i < nodes.Count; i++)
    {
        Transform leader;

        if (i == 0)
            leader = transform;          // First segment follows head
        else
            leader = nodes[i - 1];    // Others follow previous segment

        float distance = Vector3.Distance(nodes[i].position,leader.position);  // Calculate distance to leader

        if (distance > followDistance)
        {
            Vector3 direction = (leader.position - nodes[i].position).normalized;

            nodes[i].position += direction * (distance - followDistance);
        }
    }
}

}
