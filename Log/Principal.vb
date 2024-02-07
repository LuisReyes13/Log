Imports System.IO

Module Principal
    Public sRutaAplicacion As String = Environment.CurrentDirectory

    Public Enum eTipoMensaje
        eError = 1
        eAdvertencia = 2
        eInfomracion = 3
    End Enum

    Public Sub Bitacora(ByVal sMensaje As String, ByVal oTipo As eTipoMensaje)

        Dim oDate As String

        Try
            oDate = Format(Date.Today, "yyyyMMdd")

            If Not Directory.Exists(sRutaAplicacion & "\Log") Then
                Directory.CreateDirectory(sRutaAplicacion & "\Log")
            End If

            If Not File.Exists(sRutaAplicacion & $"\Log\Proyecto_Log_{oDate}.txt") Then
                Using oLogs As StreamWriter = New StreamWriter(sRutaAplicacion & $"\Log\Proyecto_Log_{oDate}.txt")
                    oLogs.WriteLine($"Logs Generados el {Date.Now}")
                    oLogs.WriteLine()
                    oLogs.WriteLine("    Día        Hora          Tipo de Mensaje           Descripción")
                    oLogs.WriteLine("------------------------------------------------------------------------")
                    oLogs.Close()
                End Using
            End If

            Using oLogs As StreamWriter = File.AppendText(sRutaAplicacion & $"\Log\Proyecto_Log_{oDate}.txt")
                oLogs.WriteLine(Date.Now & If(oTipo = eTipoMensaje.eAdvertencia Or oTipo = eTipoMensaje.eInfomracion, "      ", "        ") &
                                oTipo.ToString & If(oTipo = eTipoMensaje.eAdvertencia Or oTipo = eTipoMensaje.eInfomracion, "       ", "           ") & sMensaje)
            End Using

        Catch ex As Exception

        End Try
    End Sub
End Module
