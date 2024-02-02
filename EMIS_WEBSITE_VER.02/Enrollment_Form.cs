using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;
namespace EMIS_WEBSITE_VER._02
{
    public partial class Enrollment_Form : Form
    {
        private Word.Application wordApp;
        private Word.Document wordDoc;
        private IntPtr wordAppHandle;
        public Enrollment_Form()
        {
            InitializeComponent();
            OpenWordDocument();
        }

     
        private void OpenWordDocument()
        {
            try
            {
                // Create an instance of Word Application
                wordApp = new Word.Application();

                // Set Word to be invisible
                wordApp.Visible = false;

                // Add a new document to Word Application
                wordDoc = wordApp.Documents.Open(@"C:\Users\Dell\Desktop\Annex-Basic-Education-Enrollment-Form.docx");

                // Get the Word window handle
                IntPtr wordHandle = new IntPtr(wordApp.ActiveWindow.Hwnd);

                // Set the Word window parent to the Panel
                WordWin32.SetParent(wordHandle, panel1.Handle);
                // Adjust the size and position of the Word application window
                MoveWindow(wordHandle, 0, 0, panel1.Width, panel1.Height, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // Import the MoveWindow method from user32.dll
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private void YourForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (wordDoc != null)
            {
                wordDoc.Close();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordDoc);
            }

            if (wordApp != null)
            {
                wordApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
            }
        }
    }
    internal static class WordWin32
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    }
}

