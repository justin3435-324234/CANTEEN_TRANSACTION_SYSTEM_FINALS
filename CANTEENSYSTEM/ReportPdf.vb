Imports System.Text

' ============================================================
' PHASE 7 — ReportPdf: minimal multi-page PDF writer (no libs).
' A4 LANDSCAPE, Helvetica (WinAnsi). Anything encodable to Windows-1252
' (em dash, bullets, smart quotes, °, ×) renders as a real glyph; only
' truly-missing chars are transliterated (₱ → "PHP "), else "?".
' Column shares are measured to fit real report content with zero cuts.
' ============================================================
Public Module ReportPdf

    Private ReadOnly PdfEnc As Encoding = Encoding.GetEncoding(1252)
    ' Strict variant: .NET's default 1252 encoder silently best-fit maps
    ' missing glyphs (e.g. peso sign) to "?" — this one throws instead so
    ' CleanCell can transliterate properly. Detected by byte test, fixed.
    Private ReadOnly PdfEncStrict As Encoding = Encoding.GetEncoding(1252, New EncoderExceptionFallback(), New DecoderExceptionFallback())

    ' ChrW codes (no non-ASCII literals: the file encoding once mangled them).
    ' U+20B1 peso, U+2014/2013 dashes, U+2022 bullet, U+2192/2190 arrows,
    ' U+2026 ellipsis, U+201C/201D + U+2018/2019 quotes.
    Private Function Transliterate(ch As Char) As String
        Select Case AscW(ch)
            Case &H20B1 : Return "PHP "
            Case &H2014, &H2013 : Return "-"
            Case &H2022 : Return "-"
            Case &H2192 : Return "->"
            Case &H2190 : Return "<-"
            Case &H2026 : Return "..."
            Case &H201C, &H201D : Return """"
            Case &H2018, &H2019 : Return "'"
            Case Else : Return Nothing
        End Select
    End Function

    Private Function CleanCell(s As String) As String
        If s Is Nothing Then Return ""
        Dim t As String = s.Replace(vbCrLf, " ").Replace(vbCr, " ").Replace(vbLf, " ")
        Dim sb As New StringBuilder(t.Length)
        For Each ch As Char In t
            Dim one As String = ch.ToString()
            Dim encodable As Boolean = False
            Try
                encodable = (PdfEncStrict.GetByteCount(one) = 1)
            Catch ex As EncoderFallbackException
                encodable = False
            End Try
            If encodable Then
                sb.Append(ch) ' genuinely representable in WinAnsi
            Else
                Dim rep As String = Transliterate(ch)
                sb.Append(If(rep IsNot Nothing, rep, "?"))
            End If
        Next
        Return sb.ToString()
    End Function

    Private Function PdfEscape(s As String) As String
        Return s.Replace("\", "\\").Replace("(", "\(").Replace(")", "\)")
    End Function

    Public Function SaveGrid(title As String, subtitle As String, headers As List(Of String), rows As List(Of List(Of String)), filePath As String) As Boolean
        Try
            Dim enc As Encoding = PdfEnc
            Dim pageW As Integer = 842 ' landscape: wide grids need the room
            Dim pageH As Integer = 595
            Dim margin As Integer = 40
            Dim usable As Integer = pageW - margin * 2
            ' Relative widths for up to 7 columns; extra columns share remainder.
            ' Measured to fit the longest real cells with margin at 9pt.
            Dim rel() As Double = {0.09, 0.14, 0.2, 0.11, 0.13, 0.09, 0.24}
            Dim nCols As Integer = Math.Max(1, headers.Count)
            Dim widths As New List(Of Integer)
            For i As Integer = 0 To nCols - 1
                Dim r As Double = If(i < rel.Length, rel(i), 0.12)
                widths.Add(CInt(usable * r))
            Next

            Dim bodySize As Integer = 9
            Dim lineH As Integer = 12
            Dim topY As Integer = pageH - margin
            Dim maxLines As Integer = (topY - margin - 60) \ lineH ' room for title block

            ' Paginate: each page holds maxLines row-lines (header repeats).
            Dim pages As New List(Of List(Of List(Of String)))
            Dim cur As New List(Of List(Of String))
            For Each r In rows
                cur.Add(r)
                If cur.Count >= maxLines Then
                    pages.Add(cur)
                    cur = New List(Of List(Of String))
                End If
            Next
            If cur.Count > 0 OrElse pages.Count = 0 Then pages.Add(cur)

            Dim objects As New List(Of Byte())
            Dim offsets As New List(Of Integer)
            Dim buf As New List(Of Byte)
            Dim AddObj As Action(Of String) = Sub(s As String)
                                                  offsets.Add(buf.Count)
                                                  buf.AddRange(enc.GetBytes(s))
                                              End Sub

            ' Reserve: 1 catalog, 2 pages, 3 font. Page/content objs numbered after.
            Dim nPages As Integer = pages.Count
            Dim pageObjNos As New List(Of Integer)
            Dim contentObjNos As New List(Of Integer)
            For i As Integer = 0 To nPages - 1
                pageObjNos.Add(4 + i * 2)
                contentObjNos.Add(5 + i * 2)
            Next
            Dim kids As String = String.Join(" ", pageObjNos.Select(Function(n) $"{n} 0 R"))

            buf.AddRange(enc.GetBytes("%PDF-1.4" & vbLf))
            AddObj($"1 0 obj<</Type/Catalog/Pages 2 0 R>>endobj{vbLf}")
            AddObj($"2 0 obj<</Type/Pages/Kids[{kids}]/Count {nPages}>>endobj{vbLf}")
            AddObj($"3 0 obj<</Type/Font/Subtype/Type1/BaseFont/Helvetica>>endobj{vbLf}")

            For pi As Integer = 0 To nPages - 1
                AddObj($"{pageObjNos(pi)} 0 obj<</Type/Page/Parent 2 0 R/MediaBox[0 0 {pageW} {pageH}]/Resources<</Font<</F1 3 0 R>>>>/Contents {contentObjNos(pi)} 0 R>>endobj{vbLf}")
                Dim cs As New StringBuilder()
                Dim PutCell As Action(Of Integer, Integer, Integer, String) =
                    Sub(px As Integer, py As Integer, psize As Integer, ptext As String)
                        cs.Append($"BT /F1 {psize} Tf 1 0 0 1 {px} {py} Tm ({PdfEscape(ptext)}) Tj ET{vbLf}")
                    End Sub
                Dim Fit As Func(Of String, Integer, String) =
                    Function(ftext As String, colW As Integer) As String
                        Dim maxCh As Integer = Math.Max(4, CInt(colW / 4.5))
                        Dim t As String = CleanCell(ftext)
                        If t.Length > maxCh Then t = t.Substring(0, maxCh)
                        Return t
                    End Function
                Dim y As Integer = topY
                PutCell(margin, y, 14, CleanCell(title))
                y -= 18
                PutCell(margin, y, 9, CleanCell(subtitle) & $"  |  Page {pi + 1} of {nPages}")
                y -= 20
                ' Header row
                Dim xx As Integer = margin
                For ci As Integer = 0 To nCols - 1
                    PutCell(xx, y, 9, Fit(headers(ci), widths(ci)))
                    xx += widths(ci)
                Next
                y -= 4
                cs.Append($"{margin} {y} m {pageW - margin} {y} l S{vbLf}")
                y -= lineH
                ' Rows
                For Each r In pages(pi)
                    xx = margin
                    For ci As Integer = 0 To nCols - 1
                        Dim cellText As String = ""
                        If ci < r.Count AndAlso r(ci) IsNot Nothing Then cellText = r(ci).ToString()
                        PutCell(xx, y, 9, Fit(cellText, widths(ci)))
                        xx += widths(ci)
                    Next
                    y -= lineH
                Next
                Dim content As String = cs.ToString()
                Dim cb As Byte() = enc.GetBytes(content)
                offsets.Add(buf.Count)
                buf.AddRange(enc.GetBytes($"{contentObjNos(pi)} 0 obj<</Length {cb.Length}>>stream{vbLf}"))
                buf.AddRange(cb)
                buf.AddRange(enc.GetBytes($"{vbLf}endstream{vbLf}endobj{vbLf}"))
            Next

            Dim xrefPos As Integer = buf.Count
            Dim totalObjs As Integer = 3 + nPages * 2
            Dim xb As New StringBuilder()
            xb.Append($"xref{vbLf}0 {totalObjs + 1}{vbLf}0000000000 65535 f{vbLf}")
            For Each off In offsets
                xb.Append(off.ToString("D10") & $" 00000 n{vbLf}")
            Next
            xb.Append($"trailer<</Size {totalObjs + 1}/Root 1 0 R>>{vbLf}startxref{vbLf}{xrefPos}{vbLf}%%EOF")
            buf.AddRange(enc.GetBytes(xb.ToString()))
            System.IO.File.WriteAllBytes(filePath, buf.ToArray())
            Return True
        Catch ex As Exception
            Debug.WriteLine("ReportPdf.SaveGrid failed: " & ex.Message)
            Return False
        End Try
    End Function

End Module
