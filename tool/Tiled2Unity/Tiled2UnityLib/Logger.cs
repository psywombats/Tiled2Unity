using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiled2Unity
{
    public class Logger
    {
        public delegate void WriteLineDelegate(string line);
        public static event WriteLineDelegate OnWriteLine;

        public delegate void WriteSuccessDelegate(string line);
        public static event WriteSuccessDelegate OnWriteSuccess;

        public delegate void WriteWarningDelegate(string line);
        public static event WriteWarningDelegate OnWriteWarning;

        public delegate void WriteErrorDelegate(string line);
        public static event WriteErrorDelegate OnWriteError;

        public static void WriteLine()
        {
            WriteLine("");
        }

        public static void WriteLine(string line)
        {
            line += "\n";
            if (OnWriteLine != null)
                OnWriteLine(line);
#if !TILED_2_UNITY_LITE
            Console.Write(line);
#else
            //UnityEngine.Debug.Log(line);
#endif
        }

        public static void WriteLine(string fmt, params object[] args)
        {
            WriteLine(String.Format(fmt, args));
        }

        public static void WriteSuccess(string success)
        {
            success += "\n";
            if (OnWriteSuccess != null)
                OnWriteSuccess(success);
#if !TILED_2_UNITY_LITE
            Console.Write(success);
#else
            UnityEngine.Debug.Log(success);
#endif
        }

        public static void WriteSuccess(string fmt, params object[] args)
        {
            WriteSuccess(String.Format(fmt, args));
        }

        public static void WriteWarning(string warning)
        {
            warning += "\n";
            if (OnWriteWarning != null)
                OnWriteWarning(warning);
#if !TILED_2_UNITY_LITE
            Console.Write(warning);
#else
            UnityEngine.Debug.LogWarning(warning);
#endif
        }

        public static void WriteWarning(string fmt, params object[] args)
        {
            WriteWarning(String.Format(fmt, args));
        }

        public static void WriteError(string error)
        {
            error += "\n";
            if (OnWriteError != null)
                OnWriteError(error);
#if !TILED_2_UNITY_LITE
            Console.Write(error);
#else
            UnityEngine.Debug.LogError(error);
#endif
        }

        public static void WriteError(string fmt, params object[] args)
        {
            WriteError(String.Format(fmt, args));
        }
    }
}
