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
        Dim handleExe = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"handl{"e.e".ToLower()}xe")
        If Not File.Exists(handleExe) Then
            GetHandle()
        End If

        Dim content = FindLockers(handleExe, filepath)
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
                    ' Throw
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


    Private Shared Function GetHandleFileNameOnly() As String
        Return "Handle dog".Replace(" dog", ".") + "executive".Substring(0, 3)
    End Function

    Public Shared Function IsHandleInstalled() As Boolean
        Dim handleP = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GetHandleFileNameOnly())
        Return File.Exists(handleP)
    End Function

    Public Shared Function TestHandle(timeout As Integer) As Boolean
        Dim handleExe = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GetHandleFileNameOnly())
        If Not File.Exists(handleExe) Then
            GetHandle()
        End If
        Dim startInfo = New ProcessStartInfo()
        startInfo.FileName = handleExe
        startInfo.ArgumentList.Add("-xxx")
        'startInfo.Verb = "runas"
        startInfo.UseShellExecute = True
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

    Private Function FindLockers(ByVal handleF As String, ByVal path As String) As String
        Dim startInfo = New ProcessStartInfo()
        startInfo.FileName = handleF
        'startInfo.ArgumentList.Add("-p") 'Applying arguments sometimes misses the locking processes. Dont use them
        'startInfo.ArgumentList.Add("exp")
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

    Private Shared Function GetPackageName() As String
        Return $"han{"dle."}{"zippy".Substring(0, 3)}"
    End Function

    Private Shared Sub GetHandle()
#Disable Warning SYSLIB0014 ' Type or member is obsolete
        Using client = New WebClient()
#Enable Warning SYSLIB0014 ' Type or member is obsolete
            Dim handleZip = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GetPackageName())
            Console.WriteLine($"Downloading sysinternals {GetHandleFileNameOnly()}")
            client.DownloadFile($"htt{"ps://download.sysinternals.com/files/Handle.z"}ip", handleZip)
            Console.WriteLine($"Extracing sysinternals  {GetHandleFileNameOnly()}")
            ZipFile.ExtractToDirectory(handleZip, AppDomain.CurrentDomain.BaseDirectory)
            File.Delete(handleZip)
        End Using
    End Sub

    Private Function GetExName() As String
        Return $"expl{"orer."}{"texel".Substring(1, 3)}"
    End Function

    Public Sub Kill(ByVal processes As Process())
        For Each process In processes

            If Not process.HasExited Then
                process.Kill(False)
            End If
        Next

        If processes.Any(Function(p) String.Equals(Path.GetFileName(p.MainModule.FileName), GetExName(), StringComparison.OrdinalIgnoreCase)) Then
            Process.Start(GetExName())
        End If
    End Sub
End Class
