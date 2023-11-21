using System.Collections.ObjectModel;

namespace görselÖdevDeneme;

public partial class Yapılacaklar : ContentPage
{
    private ObservableCollection<TodoItem> TodoItems { get; set; }
	public Yapılacaklar()
    { 

    InitializeComponent();
    TodoItems = new ObservableCollection<TodoItem>();
    todoListView.ItemsSource = TodoItems;
	}

 private async void AddButton_Clicked(object sender, EventArgs e)
{

    string newNote = await DisplayPromptAsync("Not Ekle", "Yeni notu girin:");

    if (!string.IsNullOrWhiteSpace(newNote))
    {
        TodoItems.Add(new TodoItem { Note = newNote });
    }
}

private void DeleteButton_Clicked(object sender, EventArgs e)
{

    var button = (Button)sender;
    var todoItem = (TodoItem)button.BindingContext;
    TodoItems.Remove(todoItem);
}

private async void EditButton_Clicked(object sender, EventArgs e)
{
    var button = (Button)sender;
    var todoItem = (TodoItem)button.BindingContext;


    string updatedNote = await DisplayPromptAsync("Not Düzenle", "Notu güncelle:", initialValue: todoItem.Note);

    if (!string.IsNullOrWhiteSpace(updatedNote))
    {

        todoItem.Note = updatedNote;
    }
}

private void SaveButton_Clicked(object sender, EventArgs e)
{

}
}

public class TodoItem
{
    public string Note { get; set; }
    public bool IsCompleted { get; set; }
}
