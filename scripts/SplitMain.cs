using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplitMain : MonoBehaviour
{
    public static SplitMain instance;

    public GameObject uiPrefab;
    //public Canvas mainCanvas;
    public Sprite black_dotted_sprite;
    private List<GameObject> allCompnents = new List<GameObject>();

    void Awake(){
        if(instance)
            Destroy(this);
        else    
            instance = this;
    }

    public void Split(GameObject parentGameObject,string splitType,int count){
        Debug.Log("Split Called!");

        for(int i = 0 ; i < count; ++i){
            GameObject newSplitObject = Instantiate(uiPrefab,parentGameObject.transform.position,Quaternion.identity,parentGameObject.transform); 
        }

        SplittingComponent splitScriptComponent = parentGameObject.GetComponent<SplittingComponent>();

        if(splitType == "fixedRow"){
            FlexibleGridLayout component = parentGameObject.GetComponent<FlexibleGridLayout>();
            component.fitType = FlexibleGridLayout.FitType.FixedRows;
            component.rows = 1;
            component.columns = count;
             parentGameObject.GetComponent<FlexibleGridLayout>().spacing.x = 2;
        }
        if(splitType == "fixedColumn"){
            FlexibleGridLayout component = parentGameObject.GetComponent<FlexibleGridLayout>();
            component.fitType = FlexibleGridLayout.FitType.FixedRows;
            component.rows = count;
            component.columns = 1;
            parentGameObject.GetComponent<FlexibleGridLayout>().spacing.y = 0;
        }
        
        parentGameObject.GetComponent<Image>().sprite = black_dotted_sprite;

    }
}


