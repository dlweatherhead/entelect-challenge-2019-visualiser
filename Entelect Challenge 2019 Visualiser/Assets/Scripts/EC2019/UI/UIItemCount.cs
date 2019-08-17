using UnityEngine;

public class UIItemCount : MonoBehaviour {
    public GameObject[] uiComponentList;


    public void Start() {
        foreach (var o in uiComponentList) o.SetActive(false);
    }

    public void UpdateIconCount(int count) {
        if (count > uiComponentList.Length)
            foreach (var o in uiComponentList)
                o.SetActive(true);
        else
            for (var i = 0; i < uiComponentList.Length; i++)
                if (i < count)
                    uiComponentList[i].SetActive(true);
                else
                    uiComponentList[i].SetActive(false);
    }
}