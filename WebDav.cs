using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsWebDav.Constants;

namespace WinFormsWebDav
{
    public partial class WebDav : UserControl
    {
        public WebDav()
        {
            InitializeComponent();
            InitComponentData();
        }
        private void InitComponentData()
        {
            //cbDriveLetter.Items.Add("");
            for (int i = 'A'; i <= 'Z'; i++)
            {
                cbDriveLetter.Items.Add((char)i);
            }
        }


        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="doscommand"></param>
        private Tuple<bool, string> DoProcess(string doscommand)
        {
            Tuple<bool, string> result = new Tuple<bool, string>(false, string.Empty);

            Process proc = new Process();
            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.StandardInput.WriteLine(doscommand);
                proc.StandardInput.AutoFlush = true; // 前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
                proc.StandardInput.WriteLine("exit");

                //无限等待
                //proc.WaitForExit();

                ////无线等待
                //while (!proc.HasExited)
                //{
                //    proc.WaitForExit(200);
                //}

                ////最多等待3秒
                proc.WaitForExit(3000);
                //proc.Kill();
                string msg = proc.StandardOutput.ReadToEnd();
                string errormsg = proc.StandardError.ReadToEnd();
                proc.StandardError.Close();
                proc.StandardOutput.Close();
                if (string.IsNullOrEmpty(errormsg))
                {
                    result = new Tuple<bool, string>(true, msg);
                }
                else
                {
                    result = new Tuple<bool, string>(false, errormsg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                proc.Close();
                proc.Dispose();
                //if (cbIsAutoClose.SelectedIndex == 1)
                //{
                //    this.Close();
                //}
            }

            return result;
        }

        /// <summary>
        /// mount连接远程计算机
        /// </summary>
        /// <param name="path"></param>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        private bool MountWebDAV(string path = "http://qatest007.cscloud.cscad.net:6003/api/document/webdav", string userName = "admin", string passWord = "cst_Ju490XH68A5dOXRFY71JiJHzQmZyHzAWwk7aaEmzESbdu5vNDYGE8KnuUrkB")
        {
            string doscommand = string.Format(DosCommandConstants.MOUNT_WEBDAV, rtbPath.Text, tbUserName.Text, tbPassword.Text);
            Tuple<bool, string> result;
            string? driveLetter = null;
            if (cbDriveLetter.SelectedIndex >= 0)
            {
                driveLetter = cbDriveLetter.Text;

                ////这一段验证所选盘符是否可以挂载,可要可不要。
                //var tempResult = DoProcess(DosCommandConstants.GET_USED_DRIVE_LETTER);
                //if (!tempResult.Item1)
                //{
                //    rtbLog.Text += tempResult.Item2;
                //    return false;
                //}

                //var list = GetDiskDriveList(tempResult.Item2, RegexPatternConstants.GET_USED_DRIVE_LETTER, "DiskDrive");
                //if (list.Contains(driveLetter))
                //{
                //    rtbLog.Text += $"{driveLetter}已存在,无法挂载\n";
                //    return false;
                //}

                doscommand = string.Format(DosCommandConstants.MOUNT_WEBDAV_BY_DRIVE_LETTER, rtbPath.Text, tbUserName.Text, tbPassword.Text, cbDriveLetter.Text);
            }

            result = DoProcess(doscommand);
            if (result.Item1)
            {
                rtbLog.Text += result.Item2;
                rtbLog.Text += $"挂载盘符为:\n{driveLetter ?? GetDiskDriveList(result.Item2, RegexPatternConstants.GET_MOUNT_DISK_DRIVE, "DiskDrive").FirstOrDefault()}\n";
            }
            else
            {
                rtbLog.Text += result.Item2;
            }

            return result.Item1;
        }


        /// <summary>
        /// 获取磁盘列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        private List<string> GetDiskDriveList(string input, string pattern, string group)
        {
            List<string> list = new List<string>();
            Regex reg = new Regex(pattern);
            var matchs = reg.Matches(input);
            if (matchs.Count > 0)
            {
                list.AddRange(matchs.Select(p => p.Groups[group].Value));
            }
            return list;
        }

        /// <summary>
        /// 获取挂载列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGetWebDavList_Click(object sender, EventArgs e)
        {
            var result = DoProcess(DosCommandConstants.GET_USED_DRIVE_LETTER);

            if (!result.Item1)
            {
                rtbLog.Text += result.Item2;
                return;
            }

            var list = GetDiskDriveList(result.Item2, RegexPatternConstants.GET_USED_DRIVE_LETTER, "DiskDrive");
            rtbLog.Text += $"挂载列表:\n{string.Join('\n', list)}\n";
        }

        /// <summary>
        /// 挂载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btMountWebdav_Click(object sender, EventArgs e)
        {
            MountWebDAV(rtbPath.Text, tbUserName.Text, tbPassword.Text);
        }

        /// <summary>
        /// 解挂
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btUnMountWebDav_Click(object sender, EventArgs e)
        {
            string doscommand = DosCommandConstants.UN_MOUNT_ALL_WEBDAV;
            if (cbDriveLetter.SelectedIndex >= 0)
            {
                doscommand = string.Format(DosCommandConstants.UN_MOUNT_WEBDAV, cbDriveLetter.Text);
            }

            var result = DoProcess(doscommand);

            rtbLog.Text += result.Item2;
        }

        /// <summary>
        /// 清除日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClear_Click(object sender, EventArgs e)
        {
            rtbLog.Text = string.Empty;
        }
    }
}
