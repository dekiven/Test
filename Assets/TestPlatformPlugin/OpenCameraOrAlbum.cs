﻿// Unity调用ios的相机相册
// https://blog.csdn.net/kangying3769/article/details/80369341

using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class OpenCameraOrAlbum : MonoBehaviour
{
    //[SerializeField] private Button _openCamera; //打开相机按钮
    //[SerializeField] private Button _openAlbum; //打开相册按钮
    [SerializeField] private Button _openCamera1; //打开相机按钮
    [SerializeField] private Button _openAlbum1; //打开相册按钮
    [SerializeField] private RawImage _image; //用于显示的图片
    ////引入在oc中定义的那两个方法
    //[DllImport("__Internal")]
    //private static extern void IOS_OpenCamera();
    //[DllImport("__Internal")]
    //private static extern void IOS_OpenAlbum();

    [DllImport("__Internal")]
    private static extern void GFTakePhoto();

    [DllImport("__Internal")]
    private static extern void GFTakeAlbum();

    void Awake()
    {
        //为两个button添加点击事件
        //_openCamera.onClick.AddListener(IOS_OpenCamera);
        //_openAlbum.onClick.AddListener(IOS_OpenAlbum);

        _openCamera1.onClick.AddListener(GFTakePhoto);
        _openAlbum1.onClick.AddListener(GFTakeAlbum);
    }
    //ios回调unity的函数
    void Message(string filenName)
    {
        //我们传进来的只是文件名字 这里合成路径
        string filePath = Application.persistentDataPath + "/" + filenName;
        //开启一个协程加载图片
        StartCoroutine(HttpGetTexture(filePath));
        // StartCoroutine(HttpGetTexture(filenName));
        Debug.LogWarningFormat("\n\tfilenName:{0}, \n\tfilePath:{1}", filenName, filePath);
    }
    IEnumerator HttpGetTexture(string url)
    {
        string pre = "file://";
        if (Application.platform == RuntimePlatform.Android)
        {
            pre = "";
        }
        using (WWW www = new WWW(pre+url))
        {
            yield return www;
            // yield return request.SendWebRequest();
            _image.texture = www.texture;
            _image.SetNativeSize();

        }
    }

}
