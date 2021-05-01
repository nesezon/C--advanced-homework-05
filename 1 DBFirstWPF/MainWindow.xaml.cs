using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using DBFirstWPF.EntityFramework;

namespace DBFirstWPF {
  public static class CollectionUtility {
    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumeration) {
      return new ObservableCollection<T>(enumeration);
    }
  }
  public partial class MainWindow : Window {
    readonly Entities entities = new Entities();
    readonly ObservableCollection<MyTable> dbdatas;

    public MainWindow() {
      InitializeComponent();
      dbdatas = entities.MyTable.ToObservableCollection();
      DataContext = dbdatas;
    }
  }
}
