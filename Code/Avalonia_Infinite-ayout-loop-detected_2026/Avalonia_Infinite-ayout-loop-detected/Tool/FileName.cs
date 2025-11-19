using System;
using System.Collections.Generic;
using System.Text;

namespace Avalonia_Infinite_ayout_loop_detected;

public class FileName
{
    public const string AppName = "Avalonia_Infinite-ayout-loop-detected";
    static public string GetAppDataPath()
    {
        string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string appFolder = System.IO.Path.Combine(appData, AppName);
        if (!System.IO.Directory.Exists(appFolder))
        {
            System.IO.Directory.CreateDirectory(appFolder);
        }
        return appFolder;
    }

} 


