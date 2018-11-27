using Domain;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string indexSelected = null;
        private string indexSelected2 = null;
        Teacher user2;
        Student user1;
        private int ind;
        private string contextStr = null;

        private void LogBtn_Click(object sender, EventArgs e)
        {
            if (LogBtn.Text == "Login")
            {
                if (Login())
                {
                    LogBtn.Text = "Logout";
                    LoginLabel.Visible = false;
                    TxtBoxLogin.Visible = false;
                    ViewPanel.Visible = true;
                    InfoShow();
                }
            }
            else
            {
                Logout();
                LogBtn.Text = "Login";
                LoginLabel.Visible = true;
                TxtBoxLogin.Visible = true;
                ViewPanel.Visible = false;
            }
        }

        private void InfoShow()
        {
            if (ind == 1)
            {
                DataGridViewComboBoxCell cell_CB = new DataGridViewComboBoxCell();
                cell_CB.Items.AddRange(new string[] { "Расписание", "Группа", "Оценки" });
                InfoDataGridView.Rows.Add();
                InfoDataGridView.Rows[0].Cells[0] = cell_CB;
            }
            if (ind == 2)
            {
                DataGridViewComboBoxCell cell_CB = new DataGridViewComboBoxCell();
                cell_CB.Items.AddRange(new string[] { "Расписание", "Оценки"});
                InfoDataGridView.Rows.Add();
                InfoDataGridView.Rows[0].Cells[0] = cell_CB;
            }
            if (ind == 0)
            {
                DataGridViewComboBoxCell cell_CB = new DataGridViewComboBoxCell();
                cell_CB.Items.AddRange(new string[] { "tbMarks" });
                InfoDataGridView.Rows.Add();
                InfoDataGridView.Rows[0].Cells[0] = cell_CB;
                InfoDataGridView.AllowUserToAddRows = true;
            }
        }

        private void Logout()
        {
            InfoDataGridView.AllowUserToAddRows = false;
            indexSelected = null;
            user2 = null;
            user1 = null;
            ind = -1;
            for (int i = 1; i < InfoDataGridView.Columns.Count;)
                InfoDataGridView.Columns.Remove(InfoDataGridView.Columns[i]);
            for (int i = 1; i < InfoDataGridView.Rows.Count;)
                InfoDataGridView.Rows.Remove(InfoDataGridView.Rows[i]);
        }

        private bool Login()
        {
            var students = Unit.StudentsRepository.AllItems;
            var teachers = Unit.TeachersRepository.AllItems;
            List<string> userId = TxtBoxLogin.Text.Split(' ').ToList();
            if (TxtBoxLogin.Text.Equals("Admin"))
            {
                ind = 0;
                return true;
            }
            if (userId.Count > 1)
            {
                foreach (var user in students)
                {
                    if ((user.FirstName == userId[0]) &&
                            (user.LastName == userId[userId.Count - 1]))
                    {
                        ind = 1;
                        user1 = user;
                        return true;
                    }
                }
                foreach (var user in teachers)
                {
                    if ((user.FirstName == userId[0]) &&
                            (user.LastName == userId[userId.Count - 1]))
                    {
                        ind = 2;
                        user2 = user;
                        return true;
                    }
                }
            }
            return false;
        }

        private void TxtBoxLogin_MouseDown(object sender, MouseEventArgs e)
        {
            TxtBoxLogin.Text = TxtBoxLogin.Text == "Login" ? "" : TxtBoxLogin.Text;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            DataGridViewComboBoxCell cell_CB = InfoDataGridView.Rows[0].Cells[0] as DataGridViewComboBoxCell;
            if (cell_CB.EditedFormattedValue.ToString().Equals("tbMarks"))
            {
                InfoDataGridView.Columns.Add("MarkId", "MarkId");
                InfoDataGridView.Columns[1].Width = 50;
                InfoDataGridView.Columns.Add("Student", "Student");
                InfoDataGridView.Columns.Add("Value", "Value");
                InfoDataGridView.Columns[3].Width = 50;
                InfoDataGridView.Columns.Add("Subject", "Subject");
                InfoDataGridView.Columns.Add("Teacher", "Teacher");
                var stud = (from m in Unit.MarksRepository.AllItems
                            join s in Unit.StudentsRepository.AllItems
                            on m.Student.Id equals s.Id
                            join ts in Unit.TeachSubjRepository.AllItems
                            on m.TeachSubj.Id equals ts.Id
                            join teachers in Unit.TeachersRepository.AllItems
                            on ts.TeacherId equals teachers.Id
                            join ss in Unit.SubjectsRepository.AllItems
                            on ts.SubjId equals ss.Id
                            select new
                            {
                                m.Id,
                                sId=s.Id,
                                s.LastName,
                                m.StudentsMark,
                                Teacher = teachers.LastName,
                                ss.Name
                            }).ToList();
                int i = 1;
                foreach (var mark in stud)
                {
                    DataGridViewRow row = InfoDataGridView.Rows[i];
                    if (row.Cells[1].Value.ToString() == mark.Id.ToString())
                    {
                        bool flagUpdate = false;
                        if (row.Cells[2].Value.ToString() != mark.LastName)
                            flagUpdate = true;
                        if (row.Cells[3].Value.ToString()!= mark.StudentsMark.ToString())
                            flagUpdate = true;
                        if (row.Cells[4].Value.ToString() != mark.Name)
                            flagUpdate = true;
                        if (row.Cells[5].Value.ToString() != mark.Teacher)
                            flagUpdate = true;
                        if (flagUpdate)
                            Update(mark.Id, new int[] { 
                                Int32.Parse(row.Cells[3].Value.ToString()) });
                    }
                    else
                        i--;
                    i++;
                }
            }
        }

        private void Update(int id, int[]args)
        {
            if (true)
            {
                Mark newitem = Unit.MarksRepository.GetItem(id);
                newitem.StudentsMark = args[0];
                Unit.MarksRepository.ChangeItem(newitem);
            }
        }

        private void ComboCell_work(object sender, EventArgs e)
        {
            DataGridViewComboBoxCell cell_CB = InfoDataGridView.Rows[0].Cells[0] as DataGridViewComboBoxCell;
            string str = null;
            int t = 1;
            try
            {
                DataGridViewComboBoxCell cell_CB2 = InfoDataGridView.Rows[1].Cells[0] as DataGridViewComboBoxCell;
                str = cell_CB2.EditedFormattedValue.ToString();
            }
            catch { str = null; }
            if(cell_CB.EditedFormattedValue.ToString()=="Оценки" && ind==2)
                t = 2;
            if (indexSelected != cell_CB.EditedFormattedValue.ToString() ||
                indexSelected2 != str)
            {
                indexSelected = cell_CB.EditedFormattedValue.ToString();
                indexSelected2 = str;
                for (int i = 1; i < InfoDataGridView.Columns.Count;)
                    InfoDataGridView.Columns.Remove(InfoDataGridView.Columns[i]);
                try
                {
                    for (int i = t; i < InfoDataGridView.Rows.Count;)
                        InfoDataGridView.Rows.Remove(InfoDataGridView.Rows[i]);
                }
                catch { }

                if (ind == 1)
                    StudentUX(cell_CB);
                else if (ind == 2)
                    TeacherUX(cell_CB);
                else if (ind == 0)
                    AdminUX(cell_CB);
            }
        }

        private void AdminUX(DataGridViewComboBoxCell cell_CB)
        {
            if (cell_CB.EditedFormattedValue.ToString().Equals("tbMarks"))
            {
                InfoDataGridView.Columns.Add("MarkId", "MarkId");
                InfoDataGridView.Columns[1].Width = 50;
                InfoDataGridView.Columns.Add("Student", "Student");
                InfoDataGridView.Columns.Add("Value", "Value");
                InfoDataGridView.Columns[3].Width = 50;
                InfoDataGridView.Columns.Add("Subject", "Subject");
                InfoDataGridView.Columns.Add("Teacher", "Teacher");
                var stud = (from m in Unit.MarksRepository.AllItems
                            join s in Unit.StudentsRepository.AllItems
                            on m.Student.Id equals s.Id
                            join ts in Unit.TeachSubjRepository.AllItems
                            on m.TeachSubj.Id equals ts.Id
                            join teachers in Unit.TeachersRepository.AllItems
                            on ts.TeacherId equals teachers.Id
                            join ss in Unit.SubjectsRepository.AllItems
                            on ts.SubjId equals ss.Id
                            select new
                            {
                                m.Id,
                                s.LastName,
                                m.StudentsMark,
                                Teacher = teachers.LastName,
                                ss.Name
                            }).ToList();

                foreach (var mark in stud)
                    InfoDataGridView.Rows.Add("", mark.Id, mark.LastName, 
                        mark.StudentsMark, mark.Name, mark.Teacher);
            }
        }

        private void TeacherUX(DataGridViewComboBoxCell cell_CB)
        {
            if (cell_CB.EditedFormattedValue.ToString().Equals("Расписание"))
            {
                var stud =
                    (from l in Unit.AudLectRepository.AllItems
                     join g in Unit.GroupsRepository.AllItems
                     on l.Group.Id equals g.Id
                     join ts in Unit.LectionsRepository.AllItems
                     on l.LectId equals ts.Id
                     join a in Unit.AudiencesRepository.AllItems
                     on l.AudId equals a.Id
                     join teas in Unit.TeachSubjRepository.AllItems
                     on l.TeachSubj.Id equals teas.Id
                     join teachers in Unit.TeachersRepository.AllItems
                     on teas.TeacherId equals teachers.Id
                     join ss in Unit.SubjectsRepository.AllItems
                     on teas.SubjId equals ss.Id
                     select new
                     {
                         l.GroupId,
                         teachers.Id,
                         Group = g.Name,
                         ts.Day,
                         ts.Start,
                         ts.Finish,
                         Audience = a.Name,
                         Teacher = teachers.LastName + " " + teachers.FirstName,
                         Subject = ss.Name

                     }).ToList();

                var _id = user2.Id;
                GridAdd(1, "group");
                GridAdd(2, "day");
                GridAdd(2, "start");
                GridAdd(2, "end");
                GridAdd(2, "Auditory");
                GridAdd(2, "Teacher");
                GridAdd(2, "Subject");

                foreach (var lect in stud)
                {
                    if (lect.Id == _id)
                        InfoDataGridView.Rows.Add("", lect.Group, lect.Day,
                            $"{lect.Start.Hour}:{lect.Start.Minute}",
                            $"{lect.Finish.Hour}:{lect.Finish.Minute}",
                            lect.Audience, lect.Teacher, lect.Subject);
                }
            }
            else if (cell_CB.EditedFormattedValue.ToString().Equals("Оценки"))
            {
                int id = user2.Id;

                InfoDataGridView.Columns.Add("Subj", "Subj");
                InfoDataGridView.Columns.Add("Group", "Group");
                InfoDataGridView.Columns.Add("Student", "Student");
                InfoDataGridView.Columns.Add("Mark", "Mark");

                var stud = (from m in Unit.MarksRepository.AllItems
                            join s in Unit.StudentsRepository.AllItems
                            on m.Student.Id equals s.Id
                            join ts in Unit.TeachSubjRepository.AllItems
                            on m.TeachSubj.Id equals ts.Id
                            join teachers in Unit.TeachersRepository.AllItems
                            on ts.TeacherId equals teachers.Id
                            join ss in Unit.SubjectsRepository.AllItems
                            on ts.SubjId equals ss.Id
                            select new
                            {
                                teachers.Id,
                                m.StudentsMark,
                                Group = s.Group.Name,
                                GroupId = s.Group.Id,
                                s.LastName,
                                ss.Name
                            }).ToList();

                DataGridViewComboBoxCell cellSubjects_CB;
                bool flag = true;
                string str = null;
                try
                {
                    cellSubjects_CB = InfoDataGridView.Rows[1].Cells[0] as DataGridViewComboBoxCell;
                    str = cellSubjects_CB.EditedFormattedValue.ToString();
                }
                catch
                {
                    flag = false;
                    cellSubjects_CB = new DataGridViewComboBoxCell();
                }
                List<string> groups = new List<string>();

                foreach (var mark in stud)
                    if (mark.Id == id)
                    {
                        if (flag)
                        {
                            if (str == mark.Group)
                                InfoDataGridView.Rows.Add("", mark.Name,
                                    mark.Group, mark.LastName, mark.StudentsMark);
                            else if (str == "All")
                                InfoDataGridView.Rows.Add("", mark.Name,
                                    mark.Group, mark.LastName, mark.StudentsMark);
                        }
                        else
                            InfoDataGridView.Rows.Add("", mark.Name,
                                mark.Group, mark.LastName, mark.StudentsMark);
                        if (!groups.Contains(mark.Group))
                            groups.Add(mark.Group);
                    }

                if (!flag)
                {
                    groups.Add("All");
                    cellSubjects_CB.Items.AddRange(groups.ToArray());
                    if (InfoDataGridView.Rows.Count == 1)
                        InfoDataGridView.Rows.Add();
                    InfoDataGridView.Rows[1].Cells[0] = cellSubjects_CB;
                }
            }
        }

        private void StudentUX(DataGridViewComboBoxCell cell_CB)
        {
            if (cell_CB.EditedFormattedValue.ToString().Equals("Расписание"))
            {
                var stud =
                    (from l in Unit.AudLectRepository.AllItems
                     join g in Unit.GroupsRepository.AllItems
                     on l.Group.Id equals g.Id
                     join ts in Unit.LectionsRepository.AllItems
                     on l.LectId equals ts.Id
                     join a in Unit.AudiencesRepository.AllItems
                     on l.AudId equals a.Id
                     join teas in Unit.TeachSubjRepository.AllItems
                     on l.TeachSubj.Id equals teas.Id
                     join teachers in Unit.TeachersRepository.AllItems
                     on teas.TeacherId equals teachers.Id
                     join ss in Unit.SubjectsRepository.AllItems
                     on teas.SubjId equals ss.Id
                     select new
                     {
                         l.GroupId,
                         Group = g.Name,
                         ts.Day,
                         ts.Start,
                         ts.Finish,
                         Audience = a.Name,
                         Teacher = teachers.LastName + " " + teachers.FirstName,
                         Subject = ss.Name

                     }).ToList();

                var _group = user1.Group.Id;
                GridAdd(1, "group");
                GridAdd(2, "day");
                GridAdd(2, "start");
                GridAdd(2, "end");
                GridAdd(2, "Auditory");
                GridAdd(2, "Teacher");
                GridAdd(2, "Subject");

                foreach (var lect in stud)
                {
                    if (lect.GroupId == _group)
                        InfoDataGridView.Rows.Add("", lect.Group, lect.Day,
                            $"{lect.Start.Hour}:{lect.Start.Minute}",
                            $"{lect.Finish.Hour}:{lect.Finish.Minute}",
                            lect.Audience, lect.Teacher, lect.Subject);
                }
            }
            else if (cell_CB.EditedFormattedValue.ToString().Equals("Группа"))
            {
                InfoDataGridView.Columns.Add("FirstName", "FirstName");
                InfoDataGridView.Columns.Add("LastName", "LastName");
                InfoDataGridView.Columns.Add("Birthday", "Birthday");
                InfoDataGridView.Columns.Add("LogBook", "LogBook");
                InfoDataGridView.Columns.Add("Email", "Email");
                InfoDataGridView.Columns.Add("Address", "Address");
                InfoDataGridView.Columns.Add("Phone", "Phone");
                int id = user1.Id;
                string groupId = null;

                var stud = (from p in Unit.PhonesRepository.AllItems
                            join s in Unit.StudentsRepository.AllItems
                            on p.Student.Id equals s.Id
                            join g in Unit.GroupsRepository.AllItems
                            on s.Group.Id equals g.Id
                            select new
                            {
                                s.Id,
                                s.FirstName,
                                s.LastName,
                                Logbook = s.LogbookNumber,
                                Number = p.StudentsPhone,
                                s.Birthday,
                                s.Email,
                                s.Address,
                                Group = g.Name
                            }).ToList();

                foreach (var st in stud)
                    if (st.Id == id)
                        groupId = st.Group;

                foreach (var st in stud)
                    if (st.Group == groupId)
                        InfoDataGridView.Rows.Add("", st.FirstName, st.LastName,
                            st.Birthday.ToString("dd/MM/yyyy"),
                            st.Logbook, st.Email, st.Address, st.Number);
            }
            else if (cell_CB.EditedFormattedValue.ToString().Equals("Оценки"))
            {
                int id = user1.Id;
                InfoDataGridView.Columns.Add("Mark", "Mark");
                InfoDataGridView.Columns.Add("Subj", "Subj");
                InfoDataGridView.Columns.Add("Teacher", "Teacher");

                var stud = (from m in Unit.MarksRepository.AllItems
                            join s in Unit.StudentsRepository.AllItems
                            on m.Student.Id equals s.Id
                            join ts in Unit.TeachSubjRepository.AllItems
                            on m.TeachSubj.Id equals ts.Id
                            join teachers in Unit.TeachersRepository.AllItems
                            on ts.TeacherId equals teachers.Id
                            join ss in Unit.SubjectsRepository.AllItems
                            on ts.SubjId equals ss.Id
                            select new
                            {
                                s.Id,
                                m.StudentsMark,
                                teachers.LastName,
                                ss.Name
                            }).ToList();

                foreach (var mark in stud)
                    if (mark.Id == id)
                        InfoDataGridView.Rows.Add("", mark.StudentsMark, mark.Name, mark.LastName);
            }
        }

        private void GridAdd(int t, string name)
        {
            InfoDataGridView.Columns.Add(name, name);
            InfoDataGridView.Columns[t].Width = 50;
        }

        private void InfoDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            bool flag = true;
            if (InfoDataGridView.CurrentCell.ColumnIndex == 0)
            {
                try
                {
                    ComboBox cellCombo = (ComboBox)e.Control;
                    if (cellCombo != null)
                    {
                        cellCombo.SelectionChangeCommitted -= new EventHandler(ComboCell_work);
                        cellCombo.SelectionChangeCommitted += new EventHandler(ComboCell_work);
                    }
                }
                catch {
                    flag = false;
                }
            }
            else flag = false;
            if (flag && ind == 0)
            {
                string str = InfoDataGridView.CurrentCell.EditedFormattedValue.ToString();
                if (contextStr != null && contextStr != str)
                    UpdateBtn.Visible = true;
                contextStr = str;
            }
        }
    }
}
