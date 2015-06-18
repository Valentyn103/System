using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Management;

namespace TreeProcess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///    
    public static class ProcessExtensions
    {
        public static List<Process> GetChildProcesses(this Process process)
        {
            var results = new List<Process>();

            // query the management system objects for any process that has the current
            // process listed as it's parentprocessid
            string queryText = string.Format("select processid from win32_process where parentprocessid = {0}", process.Id);
            using (var searcher = new ManagementObjectSearcher(queryText))
            {
                foreach (var obj in searcher.Get())
                {
                    object data = obj.Properties["processid"].Value;
                    if (data != null)
                    {
                        // retrieve the process
                        var childId = Convert.ToInt32(data);
                        var childProcess = Process.GetProcessById(childId);

                        // ensure the current process is still live
                        if (childProcess != null)
                            results.Add(childProcess);
                    }
                }
            }
            return results;
        }

        public static int? GetParentId(this Process process)
        {
            // query the management system objects
            string queryText = string.Format("select parentprocessid from win32_process where processid = {0}", process.Id);
            using (var searcher = new ManagementObjectSearcher(queryText))
            {
                foreach (var obj in searcher.Get())
                {
                    object data = obj.Properties["parentprocessid"].Value;
                    if (data != null)
                        return Convert.ToInt32(data);
                }
            }
            return null;
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Process[] AllProcess = Process.GetProcesses();
            List<Process> ParentProcess = new List<Process>();
            List<Process> ChildProcess = new List<Process>();

            for (int i = 0; i < AllProcess.Length; i++)
            {
                if (0 == GetParentProcessId(AllProcess[i].Id))
                {
                    TreeViewItem treeItem = null;
                    treeItem = new TreeViewItem();
                    treeItem.Header = AllProcess[i].ProcessName;

                    ChildProcess = AllProcess[i].GetChildProcesses();
                   for(int j = 0;j<ChildProcess.Count;j++)
                    {
                        treeItem.Items.Add(new TreeViewItem() { Header = ChildProcess[j].ProcessName });
                        AddTree(AllProcess[i], treeItem,j);
                     
                    }

                    //var childProcesses1 = AllProcess[i].GetChildProcesses();
                    //foreach (var childProcess in AllProcess)
                    //{
                    //    if (AllProcess[i].Id == GetParentProcessId(childProcess.Id))
                    //    {
                    //        treeItem.Items.Add(new TreeViewItem() { Header = childProcess.ProcessName});
                    //    }
                    //}
                    Tree.Items.Add(treeItem);
                }
            }
        }

        void AddTree(Process Proc, TreeViewItem tree,int j)
        {
            List<Process> ChildProcess = new List<Process>();
            
            
            
            ChildProcess = Proc.GetChildProcesses();
            foreach (var a in ChildProcess)
            {
                tree.Items.Add(new TreeViewItem() { Header = a.ProcessName });
            }
        }


        int GetParentProcessId(int Id)
        {
            int parentId = 0;
            using (ManagementObject obj = new ManagementObject("win32_process.handle=" + Id.ToString()))
            {
                obj.Get();
                parentId = Convert.ToInt32(obj["ParentProcessId"]);
            }
            return parentId;
        }
    }
}
