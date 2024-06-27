Console.WriteLine("Hello!");



var exit = true;
List<string> todos = new List<string>();
do
{
    Console.WriteLine("\nWhat would you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
    var userChoice = Console.ReadLine();

    switch (userChoice)
    {
        case "S":
        case "s":
            selectAllTodos();
            break;
        case "A":
        case "a":
            AddTodo();
            break;
        case "R":
        case "r":
            removeTodo();
            break;
        case "E":
        case "e":
            PrintSelectedOption("Exit");
            exit = false;
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }

} while (exit);

Console.ReadKey();
void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}

// Kiểm tra biến có trong hàm todos
bool checkIfAddTodo(string todoDescription)
{
    for (int i = 0; i < todos.Count; i++)
    {
        if (todos[i] == todoDescription)
        {
            return true;
        }
    }
    return false;
}

//Kiểm tra vị trí biến trong hàm todos
bool checkIfRemoveTodo(int selectedIndex)
{
    for (int i = 0; i < todos.Count; i++)
    {
        if (i == selectedIndex)
        {
            return true;
        }
    }
    return false;
}

// in các biến trong hàm todos
void selectAllTodos()
{
    if (todos.Count == 0)
    {
        ShowNoTodoMessage();
        return;
    }
    for (int i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todos[i]} ");
    }
}

//Thêm biến vào hàm todos
void AddTodo()
{
    string todoDescription;
    do
    {
        Console.WriteLine("Enter the TODO description: ");
        todoDescription = Console.ReadLine();
    } while (!IsDescriptionValid(todoDescription));
    todos.Add(todoDescription);
    Console.WriteLine("TODO successfully added: " + todoDescription);
}

bool IsDescriptionValid(string todoDescription)
{
    if (todoDescription == "")//Kiểm tra xem biến có rỗng không
    {
        Console.WriteLine("The description cannot be empty.");
        return false;
    }
    //else if(checkIfAddTodo(todoDescription))//Kiểm tra xem biến có trong hàm todos không
    if (todos.Contains(todoDescription))
    {
        Console.WriteLine("The description must be unique.");
        return false;
    }
    return true;//Thêm biến vào hàm todos
    /*    {
            todos.Add(todoDescription);
            Console.WriteLine("TODO successfully added: " + todoDescription);
            add = false;
        }*/
}

//Xóa biến trong hàm todos
void removeTodo()
{
    if (todos.Count == 0)
    {
        ShowNoTodoMessage();
        return;
    }
    bool remove = true;
    do
    {
        Console.WriteLine("Selected index of the TODO you want to remove");
        selectAllTodos();
        var selectedIndex = Console.ReadLine();
        if (selectedIndex == "")
        {
            Console.WriteLine("Selected index cannot be empty.");
            continue;
        }
        if (int.TryParse(selectedIndex, out int index) && index >= 1 && index <= todos.Count)
        {
            var indexOfTodo = index - 1;
            var tobeRemoved = todos[indexOfTodo];
            todos.RemoveAt(indexOfTodo);
            remove = false;
            Console.WriteLine("TODO removed: " + tobeRemoved);
        }
        else
        {
            Console.WriteLine("The given index is not valid.");
        }
        /*            int index = int.Parse(selectedIndex) - 1 ;

                    if (checkIfRemoveTodo(index))//Kiểm tra xem vị trí biến có trong hàm todos không
                    {
                        var removedTodo = todos[index];
                        todos.RemoveAt(index);
                        Console.WriteLine("TODO removed: " + removedTodo );
                        remove = false;
                    }
                    else if (selectedIndex == "")//Kiểm tra xem vị trí biến có rỗng không
                    {
                        Console.WriteLine("Selected index cannot be empty.");
                    }
                    else//Kiểm tra vị trí biến có hợp lệ không
                    {
                        Console.WriteLine("The given index is not valid.");
                    }*/
    } while (remove);
}

bool TryReadIndex(out int index)
{
    var selectedIndex = Console.ReadLine();
    if (selectedIndex == "")
    {
        index = 0;
        Console.WriteLine("Selected index cannot be empty.");
        return false;
    }
    if (int.TryParse(selectedIndex, out index) && index >= 1 && index <= todos.Count)
    {
        var indexOfTodo = index - 1;
        var tobeRemoved = todos[indexOfTodo];
        todos.RemoveAt(indexOfTodo);
        Console.WriteLine("TODO removed: " + tobeRemoved);
        return true;
    }
    else
    {
        Console.WriteLine("The given index is not valid.");
    }
    /*            int index = int.Parse(selectedIndex) - 1 ;

                if (checkIfRemoveTodo(index))//Kiểm tra xem vị trí biến có trong hàm todos không
                {
                    var removedTodo = todos[index];
                    todos.RemoveAt(index);
                    Console.WriteLine("TODO removed: " + removedTodo );
                    remove = false;
                }
                else if (selectedIndex == "")//Kiểm tra xem vị trí biến có rỗng không
                {
                    Console.WriteLine("Selected index cannot be empty.");
                }
                else//Kiểm tra vị trí biến có hợp lệ không
                {
                    Console.WriteLine("The given index is not valid.");
                }*/
}

static void ShowNoTodoMessage()
{
    Console.WriteLine("No TODOs have been added yet.");
}
static void ShowInvalidChoiceMessage()
{
    Console.WriteLine("Invalid choice.");
}
