using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Vector2Int size = new Vector2Int(2, 2);// ex) 2x2 or 3x2
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.localScale = new Vector3(size.x,1,size.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBuildingSize(int buildingSize)
    {
        size = new Vector2Int(buildingSize, buildingSize);
        this.gameObject.transform.localScale = new Vector3(buildingSize,1,buildingSize);
        
    }
}
