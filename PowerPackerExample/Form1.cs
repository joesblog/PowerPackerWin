using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace PowerPackerExample
{
    public partial class Form1 : Form
    {

        [DllImport("PowerPacker32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void dumpToFile(string source, string destination);


        [DllImport("PowerPacker32.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr convert(string source);

        string pathOfCurrentFile { get; set; }
        string pathForSaveFile { get; set; }

        public Form1()
        {
            InitializeComponent();
        }


        private void otsmOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileOk += Ofd_FileOk;
            ofd.ShowDialog();

 

        }

        private void Ofd_FileOk(object sender, CancelEventArgs e)
        {
            if (((OpenFileDialog)sender).CheckFileExists)
            {
                pathOfCurrentFile = ((OpenFileDialog)sender).FileName;
                openPPFile();
            }
            else
            {
                MessageBox.Show("No file selected");
            }

        }

        private void otsmSaveAs_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileOk += Sfd_FileOk;

            sfd.ShowDialog();


      


        }


      private  void openPPFile()
        {
            try
            {
                IntPtr pt3r = new IntPtr();
                pt3r = convert(pathOfCurrentFile);
                tbOpenResult.Text = Marshal.PtrToStringAnsi(pt3r).Replace("\r\n", "\n");
            }
            catch (Exception exp)
            {
                MessageBox.Show("Something failed in opening this file, are you sure its a PP20?");
            }
        }
        private void Sfd_FileOk(object sender, CancelEventArgs e)
        {
         
                pathForSaveFile = ((SaveFileDialog)sender).FileName;

            if (pathOfCurrentFile != null && pathOfCurrentFile != "")
            {
                dumpToFile(pathOfCurrentFile, pathForSaveFile);
            }
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout fra = new frmAbout();
            fra.Show();
        }
    }
      


}
