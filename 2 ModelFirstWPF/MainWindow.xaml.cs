using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using ModelFirstWPF.EntityFramework;

namespace ModelFirstWPF {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void Load_Click(object sender, RoutedEventArgs e) {
      try {
        ModelContainer entities = new ModelContainer();
        DataContext = entities.MyTableSet.ToList();
        entities.MyTableSet.Load();
      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Ошибка обращения к БД");
      }
    }
  }
}
