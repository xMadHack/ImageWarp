using System;
using Microsoft.Win32;

public class AppDescription
{
    public virtual string AppFilenameWithoutExtension()
    {
        // Should match the name of the actualt exe file.
        throw new Exception("Must override this");
    }

    public const string PathKeyName = "Path";
    public const string EnabledKeyName = "Enabled";
    public static string ToolsFolder
    {
        get
        {
            return System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        }
    }

    private string AppSubkeyPath
    {
        get
        {
            return XMadHackSubkeyPath + @"\" + AppFilenameWithoutExtension();
        }
    }

    private static string XMadHackSubkeyPath
    {
        get
        {
            return $"Softwar{@"e\xMadH"}ack";
        }
    }

    public static string XMadHackBaseRegistryKey
    {
        get
        {
            return $"HKE{"Y_CURRENT_U"}SER\\" + XMadHackSubkeyPath;
        }
    }
    public string AppRegistryKey
    {
        get
        {
            return XMadHackBaseRegistryKey + @"\" + AppFilenameWithoutExtension();
        }
    }

    public string AppFullPath()
    {
        return System.IO.Path.Combine(ToolsFolder, AppFilenameWithoutExtension() + ".exe");
    }

    public object ReadValueFromRegistry(string name)
    {
        return Registry.GetValue(AppRegistryKey, name, null);
    }

    public void WriteValueToRegistry(string name, object value, RegistryValueKind kind)
    {
        Registry.SetValue(AppRegistryKey, name, value, RegistryValueKind.String);
    }

    public int? ReadInt32ValueFromRegistry(string name)
    {
        return (int?)Registry.GetValue(AppRegistryKey, name, null);
    }

    public void WriteInt32ValueToRegistry(string name, Int32? value)
    {
        Registry.SetValue(AppRegistryKey, name, value, RegistryValueKind.DWord);
    }

    public bool ReadBoolValueFromRegistry(string name)
    {
        var val= (int?)Registry.GetValue(AppRegistryKey, name, null);
        return val != null && val > 0;
    }

    public void WriteBoolValueToRegistry(string name, bool value)
    {
        int val = value ? 1 : 0;
        Registry.SetValue(AppRegistryKey, name, val, RegistryValueKind.DWord);
    }


    public virtual void WriteBaseRegistryValues(bool enabled = true)
    {
        WriteValueToRegistry(PathKeyName, (string)AppFullPath(), RegistryValueKind.String);
        WriteBoolValueToRegistry(EnabledKeyName,enabled);
    }

    public string ReadRegisteredPath()
    {
        return (string)ReadValueFromRegistry(PathKeyName);
    }

    public bool ReadIsEnabled()
    {
       return ReadBoolValueFromRegistry(EnabledKeyName);  
    }

    public virtual void DeleteRegistryValues()
    {
        AppKey.DeleteValue(PathKeyName);
        AppKey.DeleteValue(EnabledKeyName);
        CheckForEmptyMadHackSubKey();
    }


    public RegistryKey AppKey
    {
        get
        {
            var key = Registry.CurrentUser.OpenSubKey(AppSubkeyPath);
            if (key == null)
                return Registry.CurrentUser.CreateSubKey(AppSubkeyPath);
            else
                return key;
        }
    }
    public void DeleteKeyFromRegistry()
    {
        using (var key = Registry.CurrentUser.OpenSubKey(AppSubkeyPath))
        {
            if (key != null)
                Registry.CurrentUser.DeleteSubKeyTree(AppSubkeyPath);
        }
        CheckForEmptyMadHackSubKey();
    }

    protected void CheckForEmptyMadHackSubKey()
    {
        bool shouldDeleteKey = false;
        using (var key = Registry.CurrentUser.OpenSubKey(XMadHackSubkeyPath))
        {
            if (key != null)
                shouldDeleteKey = (key.SubKeyCount == 0 && key.ValueCount == 0);
        }
        if (shouldDeleteKey)
            Registry.CurrentUser.DeleteSubKeyTree(XMadHackSubkeyPath);
    }
}
