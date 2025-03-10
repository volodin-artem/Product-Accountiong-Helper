﻿
using System;
using System.Drawing;
using System.Windows.Forms;

namespace auth
{
	public partial class ImageTypeChoose : Form
	{
		public static PictureBox picture;
		public static uint itemId;
		
		public ImageTypeChoose()
		{
			InitializeComponent();
		}
		
		void ImageTypeChooseLoad(object sender, EventArgs e)
		{
			urlBox.GotFocus += textBox1_GotFocus;
			urlBox.LostFocus += textBox1_LostFocus;
			AllowDrop = true;
			DragEnter += ImageTypeChoose_DragEnter;
			DragDrop += UrlBoxDragDrop;
		}

		void ImageTypeChoose_DragEnter(object sender, DragEventArgs e)
		{
			object ads = e.Data;
			MessageBox.Show(ads.ToString());
		}
		void textBox1_GotFocus(object sender, EventArgs e)
		{
			if(urlBox.Focused)
			{
				if (urlBox.Text == "Введите url-адрес картинки") {
					urlBox.Clear();
				}
			}
		}

		void textBox1_LostFocus(object sender, EventArgs e)
		{
			if (!urlBox.Focused) {
				if (urlBox.Text == "") {
					urlBox.Text = "Введите url-адрес картинки";
				}
			}
		}
		public void ChooseFromCompButtonClick(object sender, EventArgs e)
		{
			openFileDialog.ShowDialog();
			if (openFileDialog.FileName != "none") {
				picture.ImageLocation = openFileDialog.FileName;
				picture.BackgroundImage = null;
				ProductCard.SetFileLocation(picture.ImageLocation, itemId);
				this.Close();
			}
		}
		public void AcceptButtonClick(object sender, EventArgs e)
		{
			if (urlBox.Text != "" && urlBox.Text != "Введите url-адрес картинки") {
				picture.ImageLocation = urlBox.Text;
				picture.BackgroundImage = null;
				ProductCard.SetFileLocation(picture.ImageLocation,itemId);
				this.Close();
			}
			else
				errorProvider.SetError(acceptButton,"Вы ничего не ввели в поле адреса!");
		}
		void UrlBoxDragDrop(object sender, DragEventArgs e)
		{
			
		}
	}
}
