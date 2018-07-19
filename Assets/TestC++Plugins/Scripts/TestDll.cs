using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Text;

public class TestDll {
	#if UNITY_IPHONE
    const string DLL_NAME = "__Internal";
	#else
	const string DLL_NAME = "test_lib";
	#endif

	[DllImport(DLL_NAME)]
	public static extern int test (int a, int b);

	[DllImport(DLL_NAME)]
	public static extern int testCPP (int a, int b);

//	[DllImport(DLL_NAME, CharSet = CharSet.Auto)]
	[DllImport(DLL_NAME)]
	private static extern IntPtr getString ();

	public static string GetString()
	{
		//		return Marshal.PtrToStringAuto (getString ());   会乱码
		return Marshal.PtrToStringAnsi (getString ());
	}

//	public static string GetStringAuto()
//	{
//		return Marshal.PtrToStringAuto (getString ());
//	}
//
//	public static string GetStringAnsi()
//	{
//		return Marshal.PtrToStringAnsi (getString ());
//	}


//	[DllImport(DLL_NAME)]
//	private static extern void getStringBuilder (ref StringBuilder sb);
//
//	public static string GetStringBuilder()
//	{
//		StringBuilder sb = new StringBuilder();
//		//getStringBuilder (ref sb);
//		return sb.ToString ();
//	}

	[DllImport(DLL_NAME)]
	public static extern bool setString (string s);

}
