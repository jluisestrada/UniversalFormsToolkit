using AutoGenerateForm.Uwp;
using System;
using UniversalFormsToolkit.BasicExample.Models;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UniversalFormsToolkit.BasicExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            AutoGenerateFormService.ForEntity<Student>().Property(s => s.FirstName).DisplayAs("Primer Nombre").WithOrder(1).VisibleWhen(s => s.FirstName != null);
            AutoGenerateFormService.ForEntity<Student>().Property(s => s.Birthday).DisplayAs("Cumpleaños");


            this.MyStudent = new Student()
            {
                LastName = "Brus",
                FirstName = "Medina",
                Semester = 6,
                Birthday = new DateTime()
                

            };
            autogenerator.CurrentDataContext = MyStudent;
        }

        #region Property
        private Student myStudent;

        public Student MyStudent
        {
            get { return myStudent; }
            set { myStudent = value; }
        }

        #endregion

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);


        }
    }


}
