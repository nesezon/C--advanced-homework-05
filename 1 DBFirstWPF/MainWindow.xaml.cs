using System;
using System.Windows;
using System.Data.Entity;
using System.Linq;
using DBFirstWPF.EntityFramework;

namespace DBFirstWPF {
  public partial class MainWindow {
    public MainWindow() {
      InitializeComponent();
    }

    private void Load_Click(object sender, RoutedEventArgs e) {
      try {
        Entities entities = new Entities();
        DataContext = entities.MyTable.ToList();
        entities.MyTable.Load();
      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Ошибка обращения к БД");
      }
    }
  }
}
