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
    public partial class AdminForm : Form
    {
        Reserve[] reservesList;
        int listSize;
        int page;
        int deleteIndex;
        int reserveIndex;
        public AdminForm()
        {
            InitializeComponent();
        }    
        public AdminForm(Reserve[] reserves, int size)
        {
            InitializeComponent();
            page = 1;
            deleteIndex = -1;
            reserveIndex = -1;
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
            if (page == 1)
            {
                CancelButton.Visible = true;
                CancelButton.Enabled = true;
                DeleteButton.Enabled = false;
                DeleteButton.Visible = false;

                InfoLabel.Text = "Info About Reserve:";
                int index = InfoList.SelectedIndex;
                reserveIndex = index;
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
                    Console.WriteLine(i + 1 + ") Population name: " + reservesList[index].List[i].Name + ", population size: " + reservesList[index].List[i].Size);
                }
                page++;
                AddButton.Enabled = true;
            }
            else
            {
                InfoLabel.Text = "Delete this population?";
                deleteIndex = InfoList.SelectedIndex;
                CancelButton.Visible = true;
                CancelButton.Enabled = true;
                DeleteButton.Enabled = true;
                DeleteButton.Visible = true;
                AddButton.Enabled = true;
            }

        }


        public static void Sync(Reserve[] reserves, int size)
        {
            for (int i = 0; i < size; i++)
            {
                FileManager.WriteInfoToFile(reserves[i].FileName, reserves[i]);

            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            deleteIndex = -1;
            reserveIndex = -1;
            page = 1;
            CancelButton.Visible = false;
            CancelButton.Enabled = false;
            PrintList(reservesList, listSize, InfoList, InfoLabel);
            

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (deleteIndex != -1)
            {
                reservesList[reserveIndex].RemovePopulation(deleteIndex);
                Sync(reservesList, listSize);
                deleteIndex = -1;
                reserveIndex = -1;
                page = 1;
                DeleteButton.Enabled = false;
                DeleteButton.Visible = false;
                PrintList(reservesList, listSize, InfoList, InfoLabel);
            }

            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (reserveIndex!=-1 && textBox2.Text != "" && textBox3.Text != "")
            {
                reservesList[reserveIndex].AddPopulation(textBox2.Text, int.Parse(textBox3.Text));

                textBox2.Text = "";
                textBox3.Text = "";
                Sync(reservesList, listSize);
                AddButton.Enabled = false;
                page = 1;
                reserveIndex = -1;
                PrintList(reservesList, listSize, InfoList, InfoLabel);
            }
        }
    }
}
