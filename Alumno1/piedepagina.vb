Imports iTextSharp.text
Imports iTextSharp.text.pdf
Public Class piedepagina
    Inherits PdfPageEventHelper

    Private ReadOnly fuentePie As New Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL, BaseColor.GRAY)

    Public Overrides Sub OnEndPage(ByVal writer As PdfWriter, ByVal document As Document)
        Dim cb As PdfContentByte = writer.DirectContent
        Dim y As Single = document.BottomMargin - 10

        ' Línea horizontal por encima del pie
        cb.SetColorStroke(New BaseColor(200, 200, 200))
        cb.SetLineWidth(0.5F)
        cb.MoveTo(document.LeftMargin, y + 6)
        cb.LineTo(document.PageSize.Width - document.RightMargin, y + 6)
        cb.Stroke()

        ' Izquierda: fecha de generación
        ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT,
            New Phrase("Generado el " & Now.ToString("dd/MM/yyyy HH:mm"), fuentePie),
            document.LeftMargin, y - 6, 0)

        ' Derecha: número de página
        ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT,
            New Phrase("Página " & writer.PageNumber.ToString(), fuentePie),
            document.PageSize.Width - document.RightMargin, y - 6, 0)
    End Sub
End Class
