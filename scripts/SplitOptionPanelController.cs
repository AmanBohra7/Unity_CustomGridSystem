using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SplitOptionPanelController : MonoBehaviour
{
    public TextMeshProUGUI counter;

    public static int coutnerValue = 0;
    public static string SeletectType = null;

    public static SplitOptionPanelController instance;
    public static GameObject splitThisGameObject;

    public Button horizontalButton;
    public Button verticalButton;
    public Sprite white_arrow;
    public Sprite black_arrow;

    void Awake(){
        if(instance) Destroy(this);
        else instance = this;
    }

    void Update(){
        counter.text = coutnerValue.ToString();
    }

    public void onIncrementCoutner() { 
        if(coutnerValue == 4){
            Debug.Log("Reached Limit: "+coutnerValue);
            return;
        }
        coutnerValue += 1; 
    }

    public void onDecrementCounter() { 
        if(coutnerValue == 0){
            Debug.Log("Underflow: "+coutnerValue);
            return;
        }
        coutnerValue -= 1; 
    }

    public void OnHorizontalSelectType() { 
        SeletectType = "fixedRow";  
        verticalButton.GetComponentInChildren<Image>().sprite = black_arrow;
        horizontalButton.GetComponent<Image>().sprite = white_arrow;
    }

    public void OnVerticalSeletType() { 
        SeletectType = "fixedColumn"; 
        verticalButton.GetComponentInChildren<Image>().sprite = white_arrow;
        horizontalButton.GetComponent<Image>().sprite = black_arrow;
    }

    public void setSplitGameObject(GameObject go){ splitThisGameObject = go; }

    public void splitNow(){
        SplitMain.instance.Split(splitThisGameObject,SeletectType,coutnerValue);
    }

}
