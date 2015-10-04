#if DEBUG || UNITY_EDITOR
#define VERBOSE
#endif

#if UNITY_EDITOR
#define VERBOSE_EXTRA
#endif

using UnityEngine;
using System.Diagnostics;
using UnityEngine.Internal;
using System;

/// <summary>
/// Custom Debug class, allows control over message severity and can disable for production builds
/// compatible with Unity asserts and other classes that use Debug (thus not namespaced under Parkerhill)
/// In addition to the standard Debug methods, adds
///     Log( msg, mask )
///     LogCat
///     LogInfo
///     LogInfoCat
///     LogErrorCat
///     LogWarningCat
/// source: http://answers.unity3d.com/questions/126315/debuglog-in-build.html
/// JSL 10/3/2015
/// </summary>
public static class Debug
{
    public static int logMask = -1;

    //
    // Summary:
    //     Opens or closes developer console.
    public static bool developerConsoleVisible {
        get { return UnityEngine.Debug.developerConsoleVisible; }
        set { UnityEngine.Debug.developerConsoleVisible = value; }
    }
    //
    // Summary:
    //     In the Build Settings dialog there is a check box called "Development Build".
    public static bool isDebugBuild {
        get { return UnityEngine.Debug.isDebugBuild; }
    }

    //
    // Summary:
    //     Assert the condition.
    [Conditional("UNITY_ASSERTIONS")]
    public static void Assert(bool condition)
    {
        UnityEngine.Debug.Assert(condition);
    }
    //
    // Summary:
    //     Assert the condition.
    [Conditional("UNITY_ASSERTIONS")]
    public static void Assert(bool condition, string message)
    {
        UnityEngine.Debug.Assert(condition, message);
    }
    //
    // Summary:
    //     Assert the condition.
    [Conditional("UNITY_ASSERTIONS")]
    public static void Assert(bool condition, string format, params object[] args)
    {
        UnityEngine.Debug.Assert(condition, format, args);
    }
    public static void Break()
    {
        UnityEngine.Debug.Break();
    }
    public static void ClearDeveloperConsole()
    {
        UnityEngine.Debug.ClearDeveloperConsole();
    }
    public static void DebugBreak()
    {
        UnityEngine.Debug.DebugBreak();
    }
    //
    // Summary:
    //     Draws a line between specified start and end points.
    public static void DrawLine(Vector3 start, Vector3 end)
    {
        UnityEngine.Debug.DrawLine(start, end);
    }
    //
    // Summary:
    //     Draws a line between specified start and end points.
    public static void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        UnityEngine.Debug.DrawLine(start, end, color);
    }
    //
    // Summary:
    //     Draws a line between specified start and end points.
    public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration)
    {
        UnityEngine.Debug.DrawLine(start, end, color, duration);
    }
    //
    // Summary:
    //     Draws a line between specified start and end points.
    public static void DrawLine(Vector3 start, Vector3 end, [DefaultValue("Color.white")] Color color, [DefaultValue("0.0f")] float duration, [DefaultValue("true")] bool depthTest)
    {
        UnityEngine.Debug.DrawLine(start, end, color, duration, depthTest);
    }
    //
    // Summary:
    //     Draws a line from start to start + dir in world coordinates.
    public static void DrawRay(Vector3 start, Vector3 dir)
    {
        UnityEngine.Debug.DrawRay(start, dir);
    }
    //
    // Summary:
    //     Draws a line from start to start + dir in world coordinates.
    public static void DrawRay(Vector3 start, Vector3 dir, Color color)
    {
        UnityEngine.Debug.DrawRay(start, dir, color);
    }
    //
    // Summary:
    //     Draws a line from start to start + dir in world coordinates.
    public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration)
    {
        UnityEngine.Debug.DrawRay(start, dir, color, duration);
    }
    //
    // Summary:
    //     Draws a line from start to start + dir in world coordinates.
    public static void DrawRay(Vector3 start, Vector3 dir, [DefaultValue("Color.white")] Color color, [DefaultValue("0.0f")] float duration, [DefaultValue("true")] bool depthTest)
    {
        UnityEngine.Debug.DrawRay(start, dir, color, duration, depthTest);
    }

    //
    // Summary:
    //    (ADDED)
    //
    [Conditional("VERBOSE_EXTRA")]
    public static void LogInfo(object message, UnityEngine.Object context = null)
    {
        UnityEngine.Debug.Log(message, context);
    }
    //
    // Summary:
    //    (ADDED)
    //
    [Conditional("VERBOSE_EXTRA")]
    public static void LogInfoCat(params object[] args)
    {
        UnityEngine.Debug.Log(string.Concat(args));
    }


    //
    // Summary:
    //    Log with masking (ADDED)
    //      give a binary mask (eg power of 2) will only get logged when Debug.debugMask matches it
    //    Example
    //      Debug.logMask = 4; 
    //      Debug.Log( "printed", 4 );
    //      Debug.Log( "not printed", 1);
    //      Debug.logMask = 5; 
    //      Debug.Log( "printed", 4 );
    //      Debug.Log( "printed", 1);
    //
    [Conditional("VERBOSE_EXTRA")]
    public static void Log(object message, int mask)
    {
        if ((Debug.logMask & mask) == mask)
        {
            UnityEngine.Debug.Log(message);
        }
    }

    //
    // Summary:
    //     Logs message to the Unity Console.
    [Conditional("VERBOSE")]
    public static void Log(object message, UnityEngine.Object context = null)
    {
        UnityEngine.Debug.Log(message, context);
    }
    //
    // Summary:
    //     Logs message to the Unity Console. (ADDED)
    [Conditional("VERBOSE")]
    public static void LogCat(params object[] args)
    {
        UnityEngine.Debug.Log(string.Concat(args));
    }
    //
    // Summary:
    //     A variant of Debug.Log that logs an error message to the console.
    public static void LogError(object message, UnityEngine.Object context = null)
    {
        UnityEngine.Debug.LogError(message, context);
    }
    //
    // Summary:
    //     A variant of Debug.Log that logs an error message to the console. (ADDED)
    public static void LogErrorCat(params object[] args)
    {
        UnityEngine.Debug.LogError(string.Concat(args));
    }
    //
    // Summary:
    //     Logs a formatted error message to the Unity console.
    public static void LogErrorFormat(string format, params object[] args)
    {
        UnityEngine.Debug.LogErrorFormat(format, args);
    }
    //
    // Summary:
    //     Logs a formatted error message to the Unity console.
    public static void LogErrorFormat(UnityEngine.Object context, string format, params object[] args)
    {
        UnityEngine.Debug.LogErrorFormat(context, format, args);
    }
    //
    // Summary:
    //     A variant of Debug.Log that logs an error message to the console.
    public static void LogException(Exception exception)
    {
        UnityEngine.Debug.LogException(exception);
    }
    //
    // Summary:
    //     A variant of Debug.Log that logs an error message to the console.
    public static void LogException(Exception exception, UnityEngine.Object context)
    {
        UnityEngine.Debug.LogException(exception, context);
    }
    //
    // Summary:
    //     Logs a formatted message to the Unity Console.
    [Conditional("VERBOSE")]
    public static void LogFormat(string format, params object[] args)
    {
        UnityEngine.Debug.LogFormat(format, args);
    }
    //
    // Summary:
    //     Logs a formatted message to the Unity Console.
    [Conditional("VERBOSE")]
    public static void LogFormat(UnityEngine.Object context, string format, params object[] args)
    {
        UnityEngine.Debug.LogFormat(context, format, args);
    }
    //
    // Summary:
    //     A variant of Debug.Log that logs a warning message to the console.
    public static void LogWarning(object message, UnityEngine.Object context = null)
    {
        UnityEngine.Debug.LogWarning(message, context);
    }
    //
    // Summary:
    //     A variant of Debug.Log that logs a warning message to the console. (ADDED)
    public static void LogWarningCat(params object[] args)
    {
        UnityEngine.Debug.LogWarning(string.Concat(args));
    }
    //
    // Summary:
    //     Logs a formatted warning message to the Unity Console.
    public static void LogWarningFormat(string format, params object[] args)
    {
        UnityEngine.Debug.LogWarningFormat(format, args);
    }
    //
    // Summary:
    //     Logs a formatted warning message to the Unity Console.
    public static void LogWarningFormat(UnityEngine.Object context, string format, params object[] args)
    {
        UnityEngine.Debug.LogWarningFormat(context, format, args);
    }
}
