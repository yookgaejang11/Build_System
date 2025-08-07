using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    /// <summary>
    /// ���콺�� ����ٴ� �ǹ� ��������
    /// </summary>
    public GameObject buildingPrefab;
    /// <summary>
    /// ���콺�� ���� �ٴ� �ǹ� ������Ʈ
    /// </summary>
    private GameObject previewObj;
    /// <summary>
    /// ������ �ǹ��� ������
    /// </summary>
    private Building buildingData;
    /// <summary>
    /// ���콺�� ������ �� ���� ���ǿ� ���� ��ȭ�Ǵ� ���� ���� ��ũ��Ʈ
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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//ī�޶�� ���°ͺ��� �޾ƿͼ� ���°� ����
            if(Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("Floor")))//out == ������ ���� ��ȯ��Ű�� �ٸ��������� ���� �������� �ٲ� Raycast == ������� �浹�� �� �ϳ�, RaycastAll == �ϴ�
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
        GameManager.Instance.OccupyArea(gridPos, buildingData.size);//������Ʈ�� �������� ���� ���� ������ ����
    }

}
