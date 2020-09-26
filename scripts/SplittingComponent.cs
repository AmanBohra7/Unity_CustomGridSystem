using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplittingComponent : MonoBehaviour
{
    private Button btn;
    private SplitMain splitInstance;

    public Sprite white_box;

    void Start(){
        splitInstance = SplitMain.instance;
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener( delegate {onClickButtonHandler();} );
    }

    private void onClickButtonHandler(){
        gameObject.GetComponent<Image>().sprite = white_box;
        SplitOptionPanelController.instance.setSplitGameObject(gameObject);
    }
}
