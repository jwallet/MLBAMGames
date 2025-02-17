﻿Imports System.Windows.Forms
Imports MetroFramework.Controls

Public Interface IMLBAMForm
    Inherits IWin32Window
    Inherits MetroFramework.Interfaces.IMetroForm

#Region "Components"
    Property tgModules As MetroToggle
    Property tgMedia As MetroToggle
    Property tgOBS As MetroToggle
    Property tgOutput As MetroToggle
    Property tgAlternateCdn As MetroToggle
    Property tgPlayer As MetroToggle
    Property tgStreamer As MetroToggle

    Property spnStreaming As MetroProgressSpinner
    Property spnLoading As MetroProgressSpinner

    Property tabMenu As MetroTabControl

    Property lblNoGames As Label

    Property lblStatus As MetroLabel
    Property lblTip As MetroLabel

    Property lnkRelease As MetroLink

    Property tbLiveRewind As MetroTrackBar

    Property chkSpotifyForceToStart As MetroCheckBox
    Property chkSpotifyPlayNextSong As MetroCheckBox
    Property chkSpotifyHotkeys As MetroCheckBox
    Property chkGameCtrl As MetroCheckBox
    Property chkGameAlt As MetroCheckBox
    Property chkGameShift As MetroCheckBox
    Property chkAdCtrl As MetroCheckBox
    Property chkAdAlt As MetroCheckBox
    Property chkAdShift As MetroCheckBox

    Property flpGames As FlowLayoutPanel

    Property txtMediaControlDelay As MetroTextBox
    Property txtGameKey As MetroTextBox
    Property txtAdKey As MetroTextBox

    Property txtStreamerPath As TextBox
    Property txtStreamerArgs As TextBox
    Property txtOutputArgs As TextBox
    Property txtMPCPath As TextBox
    Property txtVLCPath As TextBox
    Property txtMpvPath As TextBox
    Property txtPlayerArgs As TextBox

    Property cbSeasons As MetroComboBox
    Property cbServers As MetroComboBox
    Property cbStreamQuality As MetroComboBox
    Property cbLiveReplay As MetroComboBox

    Property btnDate As Button
    Property btnTomorrow As Button
    Property btnYesterday As Button

    Property rbMPV As MetroRadioButton
    Property rbMPC As MetroRadioButton
    Property rbVLC As MetroRadioButton
#End Region
#Region "Methods"
    Function GetSetting(name As String) As Object
    Sub SetSetting(name As String, value As Object)
    Function MsgBox(message As String, title As String, buttons As MessageBoxButtons, Optional type As MessageBoxIcon? = Nothing) As DialogResult
#End Region
End Interface
