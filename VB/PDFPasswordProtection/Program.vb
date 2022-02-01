Imports DevExpress.Pdf

Namespace PDFPasswordProtection

    Friend Class Program

        Shared Sub Main(ByVal args As String())
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
                encryptionOptions.OwnerPasswordString = "OwnerPassword"
                encryptionOptions.UserPasswordString = "UserPassword"
                ' Specify the 256-bit AES encryption algorithm.
                encryptionOptions.Algorithm = DevExpress.Pdf.PdfEncryptionAlgorithm.AES256
                ' Save the protected document with encryption settings.  
                pdfDocumentProcessor.SaveDocument("..\..\ProtectedDocument.pdf", New DevExpress.Pdf.PdfSaveOptions() With {.EncryptionOptions = encryptionOptions})
            End Using
        End Sub
    End Class
End Namespace
