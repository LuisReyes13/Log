Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Bitacora("Prueba de mensaje de error", eTipoMensaje.eError)
        Bitacora("Prueba de mensaje de advertencia", eTipoMensaje.eAdvertencia)
        Bitacora("Prueba de mensaje de informacion", eTipoMensaje.eInfomracion)
    End Sub
End Class
