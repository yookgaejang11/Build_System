using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    /// <summary>
    /// 마우스를 따라다닐 건물 ㅁ프리팹
    /// </summary>
    public GameObject buildingPrefab;
    /// <summary>
    /// 마우스를 따라 다닐 건물 오브젝트
    /// </summary>
    private GameObject previewObj;
    /// <summary>
    /// 생성될 건물의 데이터
    /// </summary>
    private Building buildingData;
    /// <summary>
    /// 마우스가 움직일 때 생성 조건에 따라 변화되는 색깔 관리 스크립트
    /// </summary>
    private BuildingPreview previewScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.isBuilding = !GameManager.Instance.isBuilding;
            if(previewObj == null && GameManager.Instance.isBuilding)
            {
                StartBuilding(1);
            }
            else if(previewObj != null && !GameManager.Instance.isBuilding)
            {
                Destroy(previewObj);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Instance.isBuilding = !GameManager.Instance.isBuilding;
            if (previewObj == null && GameManager.Instance.isBuilding)
            {
                StartBuilding(2);
            }
            else if (previewObj != null && !GameManager.Instance.isBuilding)
            {
                Destroy(previewObj);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameManager.Instance.isBuilding = !GameManager.Instance.isBuilding;
            if (previewObj == null && GameManager.Instance.isBuilding)
            {
                StartBuilding(3);
            }
            else if (previewObj != null && !GameManager.Instance.isBuilding)
            {
                Destroy(previewObj);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameManager.Instance.isBuilding = !GameManager.Instance.isBuilding;
            if (previewObj == null && GameManager.Instance.isBuilding)
            {
                StartBuilding(4);
            }
            else if (previewObj != null && !GameManager.Instance.isBuilding)
            {
                Destroy(previewObj);
            }
        }

        if (Input.GetMouseButton(1))
        {
            DestroyObj();
        }


        if (GameManager.Instance.isBuilding)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//카메라로 쓰는것보다 받아와서 쓰는게 나음
            if(Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("Floor")))//out == 변수의 값을 변환시키면 다른데에서의 같은 변수값도 바뀜 Raycast == 가장먼저 충돌한 애 하나, RaycastAll == 싹다
            {
                
                Vector3 hitPoint = hit.point;
                Vector2Int gridPos = new Vector2Int(Mathf.FloorToInt(hitPoint.x),Mathf.FloorToInt(hitPoint.z));
                
                Vector3 displayPos = new Vector3(gridPos.x + buildingData.size.x / 2f, 1, gridPos.y + buildingData.size.y / 2f);
                previewObj.transform.position = displayPos;

                bool canPlace = GameManager.Instance.IsAreaFree(gridPos, buildingData.size);
                previewScript.Setcolor(canPlace ? Color.green : Color.red);

                if(Input.GetMouseButtonDown(0) && canPlace)
                {
                    PlaceBuilding(gridPos);
                }
            }


            

        }
        

    }

    void DestroyObj()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitObj, 100f, LayerMask.GetMask("Obj")))
        {
            Destroy(hitObj.transform.gameObject);

        }

    }

    public void StartBuilding(int buildingSize)
    {
        previewObj = Instantiate(buildingPrefab);
        buildingData = previewObj.GetComponent<Building>();
        buildingData.SetBuildingSize(buildingSize);
        previewScript = previewObj.AddComponent<BuildingPreview>();
    }

    void PlaceBuilding(Vector2Int gridPos)
    {
        Debug.Log(buildingData.size.x);
        Vector3 spawnPos = new Vector3(gridPos.x + buildingData.size.x/2f, 1, gridPos.y + buildingData.size.y/2f);
        GameObject createBuilding = Instantiate(buildingPrefab, spawnPos, Quaternion.identity);
        createBuilding.transform.name = "CreateBuilding";
        createBuilding.GetComponent<Building>().SetBuildingSize(buildingData.size.x);
        GameManager.Instance.OccupyArea(gridPos, buildingData.size);//오브젝트가 지어짐에 따라 맵의 데이터 변경
    }

}
