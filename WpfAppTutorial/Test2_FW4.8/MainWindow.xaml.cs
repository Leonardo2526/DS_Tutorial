﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DS_Forms;

namespace Test2_FW4._8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {

            Docs docs = new Docs();

            string ext = "rvt";
            docs.GetFiles(DialogForms.SourcePath, ext);
            docs.DirIterate(DialogForms.SourcePath, ext);
            List<string>  FileList = docs.FileFullNames_Filtered;

            MessageBox.Show(FileList.Count.ToString());
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            DialogForms dialogForms = new DialogForms();
            dialogForms.AssignSourcePath();
        }
    }

}

class DialogForms
{
    public static string SourcePath { get; set; }
    public static string FamilyPath { get; set; }

    public void AssignSourcePath()
    {
        DS_Form newForm = new DS_Form
        {
            TopLevel = true
        };

        SourcePath = newForm.DS_OpenInputFolderDialogForm().ToString();
        if (SourcePath == "")
        {
            newForm.Close();
            return;
        }
    }


}

public class Docs

{
    public List<string> FileFullNames_Filtered = new List<string>();

    public void DirIterate(string CheckedPath, string ext)
    //Output files names list and it's direcories to Log
    {
        try
        {
            //Check folders
            foreach (string dir in Directory.GetDirectories(CheckedPath))
            {
                GetFiles(dir, ext);
                DirIterate(dir, ext);
            }

        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public void GetFiles(string dir, string ext)
    {
        //Get files list from current directory
        List<string> newList = FileFilter(dir, ext);
        FileFullNames_Filtered.AddRange(newList);

    }

    List<string> FileFilter(string dir, string ext)

    {
        //Extensions list
        var FileExt = new List<string> { ext };
        List<string> FileFullNames = new List<string>();


        FileFullNames = Directory.EnumerateFiles(dir, "*.*", SearchOption.TopDirectoryOnly).
        Where(s => FileExt.Contains(System.IO.Path.GetExtension(s).TrimStart((char)46).ToLowerInvariant())).ToList();

        return FileFullNames;
    }


}