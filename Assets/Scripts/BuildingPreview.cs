using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPreview : MonoBehaviour
{
    private Renderer[] renderers;

    private void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    public void Setcolor(Color color)
    {
        foreach( var r in renderers)
        {
            if(r.material.HasProperty("_Color"))//Color�� ������ �� _ ������ �ȵ�
                r.material.color = color;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
