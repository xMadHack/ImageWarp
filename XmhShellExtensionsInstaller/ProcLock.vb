Imports System
Imports System.IO
Imports System.IO.Compression
Imports System.Net

''' <summary>
''' Code taken mostly from https://github.com/vince-koch/DotNetTools
''' (MIT license).
''' 99.5% of this class credits goes to https://github.com/vince-koch
''' Code adaptation by xMadHack.
''' </summary>
Public Class ProcLock

    Public Function CheckLocks(ByVal filepath As String) As Process()
        Dim handleExe = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "handle.exe")
        If Not File.Exists(handleExe) Then
            DownloadHandleExe()
        End If

        Dim content = ExecuteHandleExe(handleExe, filepath)
        Dim pids = ParseProcessIds(content)
        Dim processes = GetProcesses(pids)

        Return processes
    End Function

    Private Function GetProcesses(ByVal pids As Integer()) As Process()
        Dim list As List(Of Process) = New List(Of Process)()

        For Each pid In pids

            Try
                Dim proc = Process.GetProcessById(pid)
                list.Add(proc)
            Catch thrown As ArgumentException

                If thrown.Message <> $"Process with an Id of {pid} is not running." Then
                    Throw
                End If
            End Try
        Next

        Return list.ToArray()
    End Function

    Private Function ParseProcessIds(ByVal content As String) As Integer()
        Const PidToken As String = " pid: "
        Const TypeToken As String = " type: "
        Dim pids = content.Split(Environment.NewLine).Where(Function(line) line.IndexOf(PidToken) > -1).Select(Function(line)
                                                                                                                   Dim start = line.IndexOf(PidToken) + PidToken.Length
                                                                                                                   Dim ends = line.IndexOf(TypeToken, start)
                                                                                                                   Dim value = line.Substring(start, ends - start)
                                                                                                                   Dim pid = Integer.Parse(value)
                                                                                                                   Return pid
                                                                                                               End Function).Distinct().ToArray()
        Return pids
    End Function

    Public Shared Function IsHandleInstalled() As Boolean
        Dim handleExe = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "handle.exe")
        Return File.Exists(handleExe)
    End Function

    Public Shared Function TestHandle(timeout As Integer) As Boolean
        Dim handleExe = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "handle.exe")
        If Not File.Exists(handleExe) Then
            DownloadHandleExe()
        End If
        Dim startInfo = New ProcessStartInfo()
        startInfo.FileName = handleExe
        startInfo.ArgumentList.Add("-xxx")
        'startInfo.RedirectStandardOutput = True
        'startInfo.UseShellExecute = False

        Using proc = Process.Start(startInfo)
            Dim ok As Boolean
            If timeout > 0 Then
                ok = proc.WaitForExit(5000)
            Else
                proc.WaitForExit()
                ok = proc.ExitCode = 0
            End If
            'Dim content = proc.StandardOutput.ReadToEnd()
            Debug.WriteLine("Test handle: " + ok.ToString())
            Return ok
        End Using
        Return False
    End Function

    Private Function ExecuteHandleExe(ByVal handleExe As String, ByVal path As String) As String
        Dim startInfo = New ProcessStartInfo()
        startInfo.FileName = handleExe
        startInfo.ArgumentList.Add("-p explorer")
        startInfo.ArgumentList.Add(path)
        startInfo.RedirectStandardOutput = True
        startInfo.UseShellExecute = False

        Using proc = Process.Start(startInfo)
            proc.WaitForExit()
            Dim content = proc.StandardOutput.ReadToEnd()
            Debug.WriteLine(content)
            Return content
        End Using
    End Function

    Private Shared Sub DownloadHandleExe()
#Disable Warning SYSLIB0014 ' Type or member is obsolete
        Using client = New WebClient()
#Enable Warning SYSLIB0014 ' Type or member is obsolete
            Dim handleZip = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "handle.zip")
            Console.WriteLine("Downloading sysinternals handle.exe")
            client.DownloadFile("https://download.sysinternals.com/files/Handle.zip", handleZip)
            Console.WriteLine("Extracing sysinternals handle.exe")
            ZipFile.ExtractToDirectory(handleZip, AppDomain.CurrentDomain.BaseDirectory)
            File.Delete(handleZip)
        End Using
    End Sub

    Public Sub Kill(ByVal processes As Process())
        For Each process In processes

            If Not process.HasExited Then
                process.Kill(False)
            End If
        Next

        If processes.Any(Function(p) String.Equals(Path.GetFileName(p.MainModule.FileName), "explorer.exe", StringComparison.OrdinalIgnoreCase)) Then
            Process.Start("explorer.exe")
        End If
    End Sub
End Class
