using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapOperation
{
    public partial class ScreenShotForm : Form
    {
        //string strPath = @"E:\Naraku\maskwork\data_code";
        public ScreenShotForm(string strPath)
        {
            InitializeComponent();
           // FileStream fs = new FileStream(strPath, FileMode.Open, FileAccess.Read);
            foreach (string Path in System.IO.Directory.GetFiles(strPath))
            {
                string PathExt = Path.Substring(Path.Length - 3, 3);
                if (PathExt == "jpg" || PathExt == "bmp" || PathExt == "png") //筛选图片格式
                {
                    ImagePaths.Add(Path);
                }
            }
            if (ImagePaths.Count != 0)
            {
                ImageCount = ImagePaths.Count; //获取图片总数
                this.pictureBox1.Image = Bitmap.FromFile(ImagePaths[0]); //加载图片
                label1.Text = System.IO.Path.GetFileName(ImagePaths[0]);
                label2.Text = "截图1";
            }
            else
                MessageBox.Show("未生成截图！");

        }
        private int ImageCount; //图片总数
        private List<string> ImagePaths = new List<string>(); //图片路径列表
        private int nowCount = 0; //已显示图片个数
        private void button1_Click(object sender, EventArgs e)
        {
            //下一张
            if (ImageCount == 1)
            {
                this.pictureBox1.Image = Bitmap.FromFile(ImagePaths[0]); //加载图片
                label1.Text = System.IO.Path.GetFileName(ImagePaths[0]);
                label2.Text = "截图1";
            }
            else
            {
                if (nowCount == ImageCount)
                {
                    nowCount = 0; //计数清零
                }
                if (nowCount > -1 & nowCount < ImageCount)
                {
                    this.pictureBox1.Image = Bitmap.FromFile(ImagePaths[nowCount]); //加载图片
                    label1.Text = System.IO.Path.GetFileName(ImagePaths[nowCount]);
                    label2.Text = "截图" + (nowCount + 1);
                    if (nowCount < ImageCount - 1)
                    {
                        nowCount++;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //上一张
            if (ImageCount == 1)
            {
                this.pictureBox1.Image = Bitmap.FromFile(ImagePaths[0]); //加载图片
                label1.Text = System.IO.Path.GetFileName(ImagePaths[0]);
                label2.Text = "截图1";
            }
            else
            {
                if (nowCount == 0)
                {
                    nowCount = ImageCount;
                }
                if (nowCount >-1 & nowCount< ImageCount)
                {
                    this.pictureBox1.Image = Bitmap.FromFile(ImagePaths[nowCount]); //加载图片
                    label1.Text = System.IO.Path.GetFileName(ImagePaths[nowCount]);
                    label2.Text = "截图" + (nowCount + 1);
                    if (nowCount > 0)
                    {
                        nowCount--;
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //文件名


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ScreenShotForm_Load(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //继续截图
            if (MessageBox.Show("要保存当前截图吗？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("保存成功!");
               ImagePaths.Clear();
                this.pictureBox1.Image.Dispose();
                this.Dispose();
            }
            else
            {
                ImagePaths.Clear();
                this.pictureBox1.Image.Dispose();
                this.Dispose();

                //if (System.IO.Directory.Exists(strPath))
                //{
                //    string[] strDirs = System.IO.Directory.GetDirectories(strPath);
                //    string[] strFiles = System.IO.Directory.GetFiles(strPath);
                //    foreach (string strFile in strFiles)
                //    {
                //        System.IO.File.Delete(strFile);
                //    }
                //    foreach (string strdir in strDirs)
                //    {
                //        System.IO.Directory.Delete(strdir, true);
                //    }
                //}

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
