Imports DevExpress.Pdf
Imports System.Security

Namespace PDFPasswordProtection

    Friend Class Program

        Shared Sub Main(ByVal args As String())
            Const ownerPasswordText As String = "OwnerPassword"
            Const userPasswordText As String = "UserPassword"
            Using pdfDocumentProcessor As DevExpress.Pdf.PdfDocumentProcessor = New DevExpress.Pdf.PdfDocumentProcessor()
                ' Load a PDF document.
                pdfDocumentProcessor.LoadDocument("..\..\Demo.pdf")
                ' Specify printing, data extraction, modification, and interactivity permissions. 
                Dim encryptionOptions As DevExpress.Pdf.PdfEncryptionOptions = New DevExpress.Pdf.PdfEncryptionOptions()
                encryptionOptions.PrintingPermissions = DevExpress.Pdf.PdfDocumentPrintingPermissions.Allowed
                encryptionOptions.DataExtractionPermissions = DevExpress.Pdf.PdfDocumentDataExtractionPermissions.NotAllowed
                encryptionOptions.ModificationPermissions = DevExpress.Pdf.PdfDocumentModificationPermissions.DocumentAssembling
                encryptionOptions.InteractivityPermissions = DevExpress.Pdf.PdfDocumentInteractivityPermissions.Allowed
                ' Specify the owner and user passwords for the document.  
                encryptionOptions.OwnerPassword = PDFPasswordProtection.Program.EncryptPassword(ownerPasswordText)
                encryptionOptions.UserPassword = PDFPasswordProtection.Program.EncryptPassword(userPasswordText)
                ' Save the protected document with encryption settings.  
                pdfDocumentProcessor.SaveDocument("..\..\ProtectedDocument.pdf", New DevExpress.Pdf.PdfSaveOptions() With {.EncryptionOptions = encryptionOptions})
            End Using
        End Sub

        Private Shared Function EncryptPassword(ByVal passwordText As String) As SecureString
            Dim password As System.Security.SecureString = New System.Security.SecureString()
            For Each c As Char In passwordText
                password.AppendChar(c)
            Next

            Return password
        End Function
    End Class
End Namespace
