﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using PDC6_Mod7_Act1.Models;
using PDC6_Mod7_Act1.Services;
using MvvmHelpers;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace PDC6_Mod7_Act1.ViewModels
{
    class StudentViewModel : BaseViewModel
    {

        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Course { get; set; }
        public int Year { get; set; }
        public string Section { get; set; }

        private DBFirebase services;

        public Command AddStudentCommand { get; }
        public ObservableCollection<Student> _students = new ObservableCollection<Student>();

        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public StudentViewModel()
        {
            services = new DBFirebase();
            Students = services.getStudent();
            AddStudentCommand = new Command(async () => await addStudentAsync(StudentID, StudentName, Course, Year, Section));
        }

        public async Task addStudentAsync(int StudentId, string StudentName, string Course, int Year, string Section)
        {
            await services.AddStudent(StudentID, StudentName, Course, Year, Section);
        }


    }
}
