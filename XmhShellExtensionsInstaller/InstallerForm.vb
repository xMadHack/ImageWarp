Imports System.IO
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports Microsoft.Win32
Imports XMadHackRegistry

Public Class InstallerForm

    Private Shared Sub Log(ByVal s As String)
        File.AppendAllText("InstallerLog.txt", DateTime.Now.ToString("HH:mm:ss:fff") + " > " + s + ControlChars.NewLine)
    End Sub

    Public Class InstallerActions
        Public Const InstallEverything As String = "installEverything"
        Public Const InstallContextMenu As String = "installContextMenu"
        Public Const InstallDdsThumbnails As String = "installDdsThumbnail"
        Public Const Uninstall As String = "uninstall"

    End Class

    Private Sub bInstall_Click(sender As Object, e As EventArgs) Handles bInstall.Click
        Log("InstallButtonClicked")
        'InstallAll(rbInstallAll.Checked Or rbInstallThumbnails.Checked, rbInstallAll.Checked Or rbInstallContextMenu.Checked)
        ''Dim asd = New XMadHackRegistry.XmhShellExtensionsDescription()
        ''Dim en1 = asd.ReadEnableContextMenu()
        ''Dim en2 = asd.ReadEnableDdsThumbnails()
        'MessageBox.Show(Me, "Installation Finished")
        Me.UseWaitCursor = True
        Dim p = New Process()
        p.StartInfo.UseShellExecute = True
        p.StartInfo.Verb = "runas"
        p.StartInfo.FileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
        If rbInstallAll.Checked Then
            p.StartInfo.Arguments = InstallerActions.InstallEverything
        ElseIf rbInstallContextMenu.Checked Then
            p.StartInfo.Arguments = InstallerActions.InstallContextMenu
        ElseIf rbInstallThumbnails.Checked Then
            p.StartInfo.Arguments = InstallerActions.InstallDdsThumbnails
        Else 'just in case
            p.StartInfo.Arguments = InstallerActions.InstallEverything
        End If
        p.Start()
        p.WaitForExit()
        Me.UseWaitCursor = False
        If p.ExitCode = 0 Then
            MessageBox.Show(Me, "Installation Finished")
        Else
            MessageBox.Show(Me, "Installation With Errors. Try Reinstalling.")
        End If
    End Sub

    Private Const NameOfXMadHackFolder As String = "xMadHack"
    Private Const NameOfTargetShellExtensionsFolder As String = "XmhShellExtensions"
    Private Const FilenameOfShellExtensionsDll As String = "XmhShellExtensions.dll"
    Private Const FilenameOfSharpShellDll As String = "SharpShell.dll"
    Private Const FilenameOfXMadHackRegistryDll As String = "XMadHackRegistry.dll"

    Private Shared Function CurrentFolder() As String
        Return IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName)
    End Function

    Private Shared ReadOnly Property SourceSharpShellDllFullPath As String
        Get
            Return IO.Path.Combine(CurrentFolder(), FilenameOfSharpShellDll)
        End Get
    End Property

    Private Shared ReadOnly Property SourceShellExtensionsDllFullPath As String
        Get
            Return IO.Path.Combine(CurrentFolder(), FilenameOfShellExtensionsDll)
        End Get
    End Property
    Private Shared ReadOnly Property SourceXMadHackDllFullPath As String
        Get
            Return IO.Path.Combine(CurrentFolder(), FilenameOfXMadHackRegistryDll)
        End Get
    End Property

    Private Shared ReadOnly Property TargetShellExtensionsDllFullPath As String
        Get
            Return IO.Path.Combine(TargetShellExtensionsDirectory, FilenameOfShellExtensionsDll)
        End Get
    End Property

    Private Shared ReadOnly Property TargetRegBatFullPath As String
        Get
            Return IO.Path.Combine(TargetShellExtensionsDirectory, "reg.bat")
        End Get
    End Property

    Private Shared ReadOnly Property TargetUnregBatFullPath As String
        Get
            Return IO.Path.Combine(TargetShellExtensionsDirectory, "unreg.bat")
        End Get
    End Property

    Private Shared ReadOnly Property SourceRegBatFullPath As String
        Get
            Return IO.Path.Combine(CurrentFolder(), "reg.bat")
        End Get
    End Property

    Private Shared ReadOnly Property SourceUnregBatFullPath As String
        Get
            Return IO.Path.Combine(CurrentFolder(), "unreg.bat")
        End Get
    End Property

    Private Shared ReadOnly Property TargetSharpShellDllFullPath As String
        Get
            Return IO.Path.Combine(TargetShellExtensionsDirectory, FilenameOfSharpShellDll)
        End Get
    End Property

    Private Shared ReadOnly Property TargetXMadHackRegistryDllFullPath As String
        Get
            Return IO.Path.Combine(TargetShellExtensionsDirectory, FilenameOfXMadHackRegistryDll)
        End Get
    End Property

    Private Shared ReadOnly Property TargetShellExtensionsDirectory As String
        Get
            Return IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), NameOfXMadHackFolder, NameOfTargetShellExtensionsFolder)
            'Return IO.Path.Combine("D:\Max\FakeProgramFiles", NameOfXMadHackFolder, NameOfTargetShellExtensionsFolder)
        End Get
    End Property

    Private Shared Function RegasmExePath() As String
        Dim regasmPath = System.Environment.ExpandEnvironmentVariables("%SystemRoot%\Microsoft.NET\Framework64\v4.0.30319\regasm.exe")
        Return regasmPath
    End Function

    Private Shared Function Quote(s As String) As String
        Return ControlChars.Quote + s + ControlChars.Quote
    End Function

    Private Shared Sub CopyShellExtensionsDllsToTarget()
        If (Not IO.Directory.Exists(TargetShellExtensionsDirectory)) Then
            IO.Directory.CreateDirectory(TargetShellExtensionsDirectory)
            Log("Directory Created: " + TargetShellExtensionsDirectory)

        End If
        If Not IO.File.Exists(SourceShellExtensionsDllFullPath) Then
            'MessageBox.Show("ERROR: Could not find " + SourceShellExtensionsDllFullPath + ". Aborting installation.")
            Log("File Not Found: " + SourceShellExtensionsDllFullPath)

            Throw New IO.FileNotFoundException(SourceShellExtensionsDllFullPath)
        End If
        If Not IO.File.Exists(SourceSharpShellDllFullPath) Then
            'MessageBox.Show("ERROR: Could not find " + SourceSharpShellDllFullPath + ". Aborting installation.")
            Log("File Not Found: " + SourceSharpShellDllFullPath)
            Throw New IO.FileNotFoundException(SourceSharpShellDllFullPath)

        End If
        If Not IO.File.Exists(SourceXMadHackDllFullPath) Then
            'MessageBox.Show("ERROR: Could not find " + SourceSharpShellDllFullPath + ". Aborting installation.")
            Log("File Not Found: " + SourceXMadHackDllFullPath)
            Throw New IO.FileNotFoundException(SourceXMadHackDllFullPath)

        End If

        IO.File.Copy(SourceShellExtensionsDllFullPath, TargetShellExtensionsDllFullPath, True)
        Log($"Copied x > y: {SourceShellExtensionsDllFullPath} > {TargetShellExtensionsDllFullPath}")

        IO.File.Copy(SourceSharpShellDllFullPath, TargetSharpShellDllFullPath, True)
        Log($"Copied x > y: {SourceSharpShellDllFullPath} > {TargetSharpShellDllFullPath}")
        IO.File.Copy(SourceXMadHackDllFullPath, TargetXMadHackRegistryDllFullPath, True)
        Log($"Copied x > y: {SourceXMadHackDllFullPath} > {TargetXMadHackRegistryDllFullPath}")

        IO.File.Copy(SourceRegBatFullPath, TargetRegBatFullPath, True)

        IO.File.Copy(SourceUnregBatFullPath, TargetUnregBatFullPath, True)

    End Sub

    Private Shared Sub DeleteShellExtensionsDllsFromTarget()

        If IO.File.Exists(TargetShellExtensionsDllFullPath) Then
            UnlockDll(TargetShellExtensionsDllFullPath)
            Threading.Thread.Sleep(1000)
            IO.File.Delete(TargetShellExtensionsDllFullPath)

        End If
        If IO.File.Exists(TargetSharpShellDllFullPath) Then
            IO.File.Delete(TargetSharpShellDllFullPath)
        End If
        If IO.File.Exists(TargetXMadHackRegistryDllFullPath) Then
            IO.File.Delete(TargetXMadHackRegistryDllFullPath)
        End If

        If IO.File.Exists(TargetRegBatFullPath) Then
            IO.File.Delete(TargetRegBatFullPath)
        End If
        If IO.File.Exists(TargetUnregBatFullPath) Then
            IO.File.Delete(TargetUnregBatFullPath)
        End If
    End Sub

    Private Shared Sub UnlockDll(dllFile As String)
        Dim pl = New ProcLock()
        Dim procs = pl.CheckLocks(dllFile)
        pl.Kill(procs)
        If procs.Length = 0 Then
            Log($"No process locking: " + dllFile)
        Else
            Log($"Killed {procs.Length.ToString()} processes locking: " + dllFile)
        End If

    End Sub

    Private Shared Sub RegisterDll(ByVal dllFile As String)
        Log($"Attempting to register DLL: " + dllFile)
        Log($"RegasmPath: " + RegasmExePath())
        If Not IO.File.Exists(RegasmExePath()) Then Throw New IO.FileNotFoundException(RegasmExePath() + " could not be found.")
        If Not IO.File.Exists(dllFile) Then Throw New IO.FileNotFoundException(dllFile + " could not be found.")
        Using p = New Process()
            p.StartInfo.RedirectStandardOutput = True
            p.StartInfo.RedirectStandardError = True
            p.StartInfo.UseShellExecute = False
            p.StartInfo.FileName = TargetRegBatFullPath
            p.Start()
            p.WaitForExit()
            Log($"Registration Output: ")
            Log(p.StandardOutput.ReadToEnd())
            Log($"Registration ErrorOutput: ")
            Log(p.StandardError.ReadToEnd())
            Log($"Dll registration finished with exit code {p.ExitCode} for: " + dllFile)

        End Using


    End Sub

    Private Shared Sub UnregisterDll(ByVal dllFile As String)
        Log($"Attempting to unregister DLL: " + dllFile)
        If Not IO.File.Exists(RegasmExePath()) Then Throw New IO.FileNotFoundException(RegasmExePath() + " could not be found.")
        If Not IO.File.Exists(dllFile) Then Throw New IO.FileNotFoundException(dllFile + " could not be found.")
        Dim p = New Process()
        p.StartInfo.FileName = TargetUnregBatFullPath
        'p.StartInfo.Arguments = "/unregister " + Quote(dllFile)
        p.Start()
        p.WaitForExit(1000)
        Log($"Dll Unregistration finished with exit code {p.ExitCode} for: " + dllFile)
    End Sub

    Public Shared Sub InstallAll(Optional enableDdsThumb As Boolean = True, Optional enableContextMenu As Boolean = True)
        Log("InstallationStarted")

        Dim texPatcherApp = New TexPatcherDescription()
        Dim imgConvertCmdApp = New ImgConvertCmdDescription()
        Dim shelExtDll = New XmhShellExtensionsDescription()


        '' 1. copy the extensions dll
        Log("Installation: Copying files")
        CopyShellExtensionsDllsToTarget()
        ' 2. create the registry keys
        Log("Installation: creating registry entries")

        texPatcherApp.WriteBaseRegistryValues()
        imgConvertCmdApp.WriteBaseRegistryValues()
        shelExtDll.WriteBaseRegistryValues(enableDdsThumb, enableContextMenu, True)
        ' 3. register the extensions dll
        RegisterDll(TargetShellExtensionsDllFullPath)
        Log("Installation finished")

    End Sub

    Public Shared Sub InstallContextMenu()
        InstallAll(False, True)
    End Sub

    Public Shared Sub InstallDdsThumbnails()
        InstallAll(True, False)
    End Sub

    Public Shared Sub Uninstall()
        Log("Unistallation started")

        '1. unregister the extensions
        '2. delete the extension files
        '3. delete the registry keys

        If IO.File.Exists(TargetShellExtensionsDllFullPath) Then
            UnregisterDll(TargetShellExtensionsDllFullPath)
            Console.WriteLine("The installer will cleanup previously installed files.")
            Console.WriteLine("If the files are locked by the System, the installer will attemp to unlock them.")
            Console.WriteLine("This process might take several seconds. Please wait.")
            Threading.Thread.Sleep(2000)
            DeleteShellExtensionsDllsFromTarget()
        End If

        Dim texPatcherApp = New TexPatcherDescription()
        Dim imgConvertCmdApp = New ImgConvertCmdDescription()
        Dim shelExtDll = New XmhShellExtensionsDescription()
        Log("Uninstallation: deleting registry entries")

        texPatcherApp.DeleteKeyFromRegistry()
        imgConvertCmdApp.DeleteKeyFromRegistry()
        shelExtDll.DeleteKeyFromRegistry()
        Log("Uninstallation finished")
    End Sub

    Private Sub bUninstall_Click(sender As Object, e As EventArgs) Handles bUninstall.Click
        If IO.File.Exists(TargetShellExtensionsDllFullPath) Then
            MessageBox.Show(Me, "XmhShelExtensions.dll is detected to be installed. Removing it might take several seconds, and could possibly restart explorer.exe process. Click OK, and please wait until the process is finished.")
            Me.UseWaitCursor = True
        End If
        Dim p = New Process()
        p.StartInfo.UseShellExecute = True
        p.StartInfo.Verb = "runas"
        p.StartInfo.FileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
        p.StartInfo.Arguments = InstallerActions.Uninstall
        p.Start()
        p.WaitForExit()
        Me.UseWaitCursor = False
        If p.ExitCode = 0 Then
            MessageBox.Show(Me, "Uninstallation Complete")
        Else
            MessageBox.Show(Me, "Uninstallation fisnihed with errors. Please try one more time.")
        End If
    End Sub


    Private Shared Sub GrantAccess(ByVal dir As String)
        Dim exists As Boolean = System.IO.Directory.Exists(dir)
        If Not exists Then
            Return
        End If
        Dim dInfo As IO.DirectoryInfo = New IO.DirectoryInfo(dir)
        Dim dSecurity As DirectorySecurity = dInfo.GetAccessControl()
        dSecurity.AddAccessRule(New FileSystemAccessRule(New SecurityIdentifier(WellKnownSidType.WorldSid, Nothing), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit Or InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow))
        dInfo.SetAccessControl(dSecurity)
    End Sub
End Class
