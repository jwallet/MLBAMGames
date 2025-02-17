﻿
Imports System.Net
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports MLBAMGames.Library
Imports MLBAMGames.Library.GitHub

Public Class GitHubAPI

    Public Const API_LATEST_RELEASES_LINK As String = "https://api.github.com/repos/MLBAMGames/MLBGames/releases"
    Public Const LATEST_RELEASE_LINK As String = "https://github.com/MLBAMGames/MLBGames/releases/latest"

    Public Shared Async Function GetReleases() As Task(Of Release())
        Dim request = Web.SetHttpWebRequest(API_LATEST_RELEASES_LINK)

        Console.WriteLine("Getting missing releases...")

        Dim content = Await Web.SendWebRequestAndGetContentAsync(Nothing, request)
        Dim releases = JsonConvert.DeserializeObject(Of Release())(content)

        If releases Is Nothing Then
            Console.WriteLine("Releases were not found.")
            Return Nothing
        End If

        Dim relatedReleases = releases.Reverse().Where(Function(r) AssemblyInfo.IsNewerVersionThanCurrent(r.tag_name, Updater.MLBGamesFullPath)).ToArray()

        If Not relatedReleases.Any() Then
            Console.WriteLine("You are already using the latest version.")
            Updater.LeaveConsole()
        End If

        Return relatedReleases
    End Function

    Public Shared Function GetZipAssetFromRelease(release As Release) As Asset
        Dim asset = release.assets.Where(Function(a) Regex.IsMatch(a.name, "^MLBGames(-|\.)(v?)(\.)?\d+(\.\d+){0,3}?(-simplified)?.zip$")).FirstOrDefault()
        If asset Is Nothing Then
            Console.WriteLine("This Release did not have any suitable asset to download. Try again later.")
            Throw New ReleaseAssetNotFoundException("This Release did not have any suitable asset to download. Try again later.")
        Else
            Console.WriteLine("Release asset found: {0}", asset.name)
        End If
        Return asset
    End Function

End Class
