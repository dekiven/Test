using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTouch : MonoBehaviour {

    public Text TextMsg;
    public Toggle[] Toggles;

    private ScreenTouchHandler handler;

    private void Start()
    {

        handler = gameObject.AddComponent<ScreenTouchHandler>();

        foreach(var toggle in Toggles)
        {
            toggle.onValueChanged.AddListener(delegate(bool v) {

                OnToogle(toggle.transform.name, v);
            });
        }

    }

    void OnToogle(string name, bool v)
    {
        switch(name)
        {
            case "click":
                if(v)
                {
                    handler.OnClick = delegate (Vector2 pos) {
                        //Debug.Log("click");
                        var s = string.Format("click :{0}", pos);
                        Debug.LogFormat(s);
                        TextMsg.text = s;
                        return true;
                    };
                }else
                {
                    handler.OnClick = null;
                }
                break;
            case "double":
                if (v)
                {
                    handler.OnDoubleClick = delegate (Vector2 pos) {
                        var s = string.Format("double click :{0}", pos);
                        Debug.LogFormat(s);
                        TextMsg.text = s;
                        return true;
                    };
                }
                else
                {
                    handler.OnDoubleClick = null;
                }
                break;
            case "long":
                if (v)
                {
                    handler.OnLongClickStart = delegate (Vector2 pos) {
                        var s = string.Format("long click :{0}", pos);
                        Debug.LogFormat(s);
                        TextMsg.text = s;
                        return true;
                    };
                }
                else
                {
                    handler.OnLongClickStart = null;
                }
                break;
            case "stati":
                if (v)
                {
                    handler.OnTouchStationary = delegate (int count, Vector2 pos) {
                        var s = string.Format("stationary click count:{0}, pos{1}", count, pos);
                        Debug.LogFormat(s);
                        TextMsg.text = s;

                        return true;
                    };
                }
                else
                {
                    handler.OnTouchStationary = null;
                }
                break;
            case "move":
                if (v)
                {
                    handler.OnTouchMove = delegate (Vector2 delta, Vector2 pos) {
                        var s = string.Format("touch move delta:{0}, pos:{1}", delta, pos);
                        Debug.LogFormat(s);
                        TextMsg.text = s;

                        return true;
                    };
                }
                else
                {
                    handler.OnTouchMove = null;
                }
                break;
            case "scale":
                if (v)
                {
                    handler.OnTouchScale = delegate (float count, Vector2 pos) {
                        var s = string.Format("touch scale :{0}, center{1}", count, pos);
                        Debug.LogFormat(s);
                        TextMsg.text = s;

                        return true;
                    };
                }
                else
                {
                    handler.OnTouchScale = null;
                }
                break;
        }

       










    }
}
