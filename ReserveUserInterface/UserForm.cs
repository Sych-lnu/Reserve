using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReserveProject;

namespace ReserveProject
{
    public partial class UserForm : Form
    {
        Reserve[] reservesList;
        int listSize;
        public UserForm()
        {
            InitializeComponent();
        }    
        public UserForm(Reserve[] reserves, int size)
        {
            InitializeComponent();
            ListBox infoList = InfoList;
            Label infoLabel = InfoLabel;
            listSize = size;
            reservesList = new Reserve[size];
            for(int i = 0; i < size; i++)
            {
                reservesList[i] = reserves[i];
            }
            PrintList(reservesList, listSize, infoList, infoLabel);
        }
        public static void PrintList(Reserve[] reserves, int size, ListBox infoList, Label infoLabel) 
        {
            Sync(reserves, size);
            infoLabel.Text = "List of Reserves";
            infoList.Items.Clear();
            for(int i = 0; i < size; i++)
            {
                infoList.Items.Add(i + 1 + ")" + reserves[i].Name);
            }
        }


        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        private void InfoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sync(reservesList, listSize);
            ReturnButton.Enabled = true;
            InfoLabel.Text = "Info About Reserve:";
            InfoList.Enabled = false;
            int index = InfoList.SelectedIndex;
            if (index < listSize)
            {
                InfoList.Items.Clear();
                int count = reservesList[index].List.Length;
                for (int i = 0; i < reservesList[index].List.Length; i++)
                {
                    if (reservesList[index].List[i] == null)
                    {
                        count = i;
                        break;
                    }
                }

                for (int i = 0; i < count; i++)
                {
                    InfoList.Items.Add(i + 1 + ") Population name: " + reservesList[index].List[i].Name + ", population size: " + reservesList[index].List[i].Size);
                }
            }
        }

        private void InfoLabel_Click(object sender, EventArgs e)
        {

        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            ReturnButton.Enabled = false;

            InfoList.Enabled = true;
            PrintList(reservesList, listSize, InfoList, InfoLabel);
        }
        public static void Sync(Reserve[] reserves, int size)
        {

            for (int i = 0; i < size; i++)
            {
                reserves[i] = new Reserve(reserves[i].FileName);
                FileManager.ReadInfoFromFile(reserves[i].FileName, reserves[i]);

            }
        }
    }
}
