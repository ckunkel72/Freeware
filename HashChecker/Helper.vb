Imports System.Collections
Imports System.ComponentModel
Imports System.Reflection

Public Class Helper

    Public Shared Function fnPathShorten(ByVal Path As String, ByVal Length As Integer) As String

        Dim PathParts() As String = Path.Split("\"c) 'Split(Path, "\")
        Dim PathBuild As New System.Text.StringBuilder(Path.Length)
        Dim LastPart As String = PathParts(PathParts.Length - 1)
        Dim PrevPath As String = LastPart

        'Erst prüfen ob der komplette String evtl. bereits kürzer als die Maximallänge ist
        If Path.Length <= Length Then
            Return Path
        End If

        For i As Integer = 0 To PathParts.Length - 1
            PathBuild.Append(PathParts(i) & "\")
            If (PathBuild.ToString & "...\" & LastPart.ToString).Length >= Length Then
                Exit For
            Else
                PrevPath = PathBuild.ToString & "...\" & LastPart
            End If
        Next

        Return PrevPath

    End Function

    Public Shared Function fnDoubleUnderlineAbschneiden(ByVal Filename As String) As String
        Return Filename.Remove(Filename.LastIndexOf("__"))
    End Function

    Public Shared Function fnDateiendungAbschneiden(ByVal Filename As String) As String
        Return Filename.Remove(Filename.LastIndexOf("."))
    End Function

End Class

Public Class EnumHelper

    Public Shared Function GetEnumDescriptions(ByVal EnumConstant As Type) As String()
        Dim strLst As New List(Of String)
        For Each ec As [Enum] In [Enum].GetValues(EnumConstant)
            strLst.Add(GetEnumDescription(ec))
        Next
        Return strLst.ToArray
    End Function

    Public Shared Function GetEnumDescription(ByVal EnumConstant As [Enum]) As String
        Dim fi As Reflection.FieldInfo = EnumConstant.GetType().GetField(EnumConstant.ToString())
        Dim attr() As System.ComponentModel.DescriptionAttribute = DirectCast(fi.GetCustomAttributes(GetType(System.ComponentModel.DescriptionAttribute), False), System.ComponentModel.DescriptionAttribute())
        If attr.Length > 0 Then
            Return attr(0).Description
        Else
            Return EnumConstant.ToString()
        End If
    End Function

    Public Shared Function ParseEnumDescrition(ByVal EnumConstant As Type, ByVal Description As String) As [Enum]
        Dim ec As [Enum] = Nothing
        For Each ec In [Enum].GetValues(EnumConstant)
            If GetEnumDescription(ec) = Description Then
                Return ec
                Exit For
            End If
        Next ec
        Return ec
    End Function

End Class