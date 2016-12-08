using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject PanelTruckChose,PanelMain;
    public List<string> TruckList;
    public List<Button> TruckButtons; 
    public GameObject prefabTruckButton;

    public GameObject TruckGameObjects; 

    void Start()
    {
        TruckButtons = new List<Button>();
        loadTruckButton();
    }
    private void loadTruckButton()
    {
//        TruckList = XmlManager.GetTruckValue();
        foreach (var t in TruckList)
        {
            GameObject go = Instantiate(prefabTruckButton);
            go.SetActive(true);
            go.transform.SetParent(prefabTruckButton.transform.parent);
            go.GetComponentInChildren<Text>().text = t;
            TruckButtons.Add(go.GetComponent<Button>());
            TruckButtons[TruckButtons.Count - 1].onClick.AddListener(LoadTruckListen);
        }
    }

    private void LoadTruckListen()
    {
        PanelTruckChose.SetActive(false);
        PanelMain.SetActive(true);
        string name = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text ;
        TruckGameObjects = Instantiate(Resources.Load(name)) as GameObject;
        TruckGameObjects.transform.SetParent(GameObject.Find("Truck").transform);
    }

    private void Unload()
    {
        TruckGameObjects = null;
        Resources.UnloadUnusedAssets();
    }
}
