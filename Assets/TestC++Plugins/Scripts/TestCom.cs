using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCom : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		Debug.Log (TestDll.test (1, 10));
//		Debug.Log (TestDll.testCPP (1, 1011));
//		Debug.Log (TestDll.GetString());
//		Debug.Log (TestDll.GetString());
////		Debug.Log (TestDll.GetStringBuilder());
//		Debug.Log (TestDll.setString("setString"));
//		Debug.Log (TestDll.setString("testSetString"));
	}

	void OnGUI()
	{
        GUIStyle fontStyle = new GUIStyle();
        fontStyle.normal.background = null;    //设置背景填充  
        fontStyle.normal.textColor = new Color(1, 0, 0);   //设置字体颜色  
        fontStyle.fontSize = 40;       //字体大小  

		string s = string.Format ("{0}: {1}\n", "TestDll.test (1, 10)", TestDll.test (1, 10));
        s += string.Format("{0}: {1}\n", "TestDll.testCPP (1, 1011)", TestDll.testCPP(1, 1011));
        s += string.Format ("{0}: {1}\n", "TestDll.GetString()", TestDll.GetString());
		s += string.Format ("{0}: {1}\n", "TestDll.setString(\"setString\")", TestDll.setString("setString"));
		s += string.Format ("{0}: {1}\n", "TestDll.setString(\"testSetString\")", TestDll.setString("testSetString"));
        Rect rect = new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 200);
        GUI.Label(rect, s, fontStyle);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
