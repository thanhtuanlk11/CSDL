﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo18_08_2021.DTO;

namespace Demo18_08_2021
{
	public partial class frmMain : Form
	{
		private RestaurantContext _context;
		public frmMain(RestaurantContext context)
		{
			_context = context;
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			LoginForm login = new LoginForm();
			if (login.ShowDialog() != DialogResult.OK)
			{
				Application.Exit();
			}

			LoadTableListFLP();
			//LoadTableListLv();
			//LoadTableToLvDetail();
		}

		private void LoadTableListFLP()
		{
			flpFloorOne.Controls.Clear();
			flpFloorTwo.Controls.Clear();
			flpFloorThree.Controls.Clear();

			var floors = new[] {flpFloorOne, flpFloorTwo, flpFloorThree};
			foreach (var table in WorkingContext.TableList)
			{
				Button btn = new Button();
				btn.Text = table.TableName + "\r\n" + (table.Status == 1 ? "Có người" : "Trống");
				btn.BackColor = table.Status == 1 ? Color.Orange: Color.Aquamarine;
				btn.Height = 40;
				btn.Width = 80;
				ttFloor.SetToolTip(btn, $"Tầng {table.Floor}");

				floors[table.Floor - 1].Controls.Add(btn);
			}
		}

		private void tsmiAdmin_Click(object sender, EventArgs e)
		{
			AdminForm form = new AdminForm(_context);
			form.ShowDialog();

			LoadTableListFLP();
		}

		/*private void LoadTableListLv()
		{
			ListViewGroup floorOne = new ListViewGroup("Tầng 1", HorizontalAlignment.Center);
			ListViewGroup floorTwo = new ListViewGroup("Tầng 2", HorizontalAlignment.Center);
			ListViewGroup floorThree = new ListViewGroup("Tầng 3", HorizontalAlignment.Center);

			lvTableList.Groups.Add(floorOne);
			lvTableList.Groups.Add(floorTwo);
			lvTableList.Groups.Add(floorThree);

			var floorGroups = new[] {floorOne, floorTwo, floorThree};
			foreach (var table in tableList)
			{
				ListViewItem item = new ListViewItem(table.TableName, table.Status);

				item.Group = floorGroups[table.Floor - 1];
				lvTableList.Items.Add(item);
			}
		}

		private void LoadTableToLvDetail()
		{
			lvTableList.Items.Clear();
			foreach (var table in tableList)
			{
				ListViewItem item = new ListViewItem(table.TableId.ToString());
				item.SubItems.Add(table.TableName);
				item.SubItems.Add(table.Status == 1 ? "Có người" : "Trống");
				item.SubItems.Add(table.Floor.ToString());

				lvTableList.Items.Add(item);
			}
		}

		*/


	}
}
