using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMN : MonoBehaviour
{
    public GameObject prePanel;
    public Transform UIContainer;

    private void Awake()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ShowPanel);
    }

    void ShowPanel()
    {
        Instantiate(prePanel, UIContainer);
    }
}
