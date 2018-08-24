using AutoGenerateForm.Uwp;
using UniversalFormsToolkit.CollectionsExample.Models;
using UniversalFormsToolkit.CollectionsExample.ViewModels;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UniversalFormsToolkit.CollectionsExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new MainPageViewModel();


            AutoGenerateFormService.ForEntity<Student>()
                                   .Property(s => s.Name)
                                   .DisplayAs("Primer Nombre")
                                   .WithOrder(1)
                                   .VisibleWhen(s => s.Name != null);
            AutoGenerateFormService.ForEntity<Group>()
                                   .CollectionProperty(g => g.Students)
                                   .DisplayMember(m => m.Name)
                                   .DisplayAs("Estudiantes")
                                   .VisibleWhen(g => g.Students != null && g.Students.Count > 0);
                                   
                                   
        }
    }
}
