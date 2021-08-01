using System;
using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.UI;

public class GAController : MonoBehaviour
{
    [SerializeField] private Button designEvent1Btn;
    [SerializeField] private Button designEvent2Btn;

    private void OnEnable()
    {
        designEvent1Btn.onClick.AddListener(ExecuteDesignEvent1);
        designEvent2Btn.onClick.AddListener(ExecuteDesignEvent2);
    }

    private void Start()
    {
        GameAnalytics.Initialize();
    }

    private void ExecuteDesignEvent1()
    {
        GameAnalytics.NewDesignEvent("UbisoftEvent1", 69);
    }
    
    private void ExecuteDesignEvent2()
    {
        GameAnalytics.NewDesignEvent("UbisoftEvent2");
    }
    
}
