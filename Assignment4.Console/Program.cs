using Assignment4.Domain;
using System.Diagnostics;

var jerry = new ChatBot("Jerry", "I was created by Nour Eldin");
var flag = true;

jerry.instructions();
Console.WriteLine("\n///////////////////////////////////////////\n");
jerry.Intro();

Debug.Assert(flag == true);

while (flag)
{
    var input = jerry.chat();

    Debug.WriteLine($"Testing the following input for exceptions: {input}");
    try
    {
        switch (input)
        {
            case "1":
                jerry.EnterUsername();
                break;
            case "2":
                jerry.EnterBirthDate();
                break;
            case "3":
                jerry.GetDate();
                break;
            case "4":
                jerry.GetTime();
                break;
            case "5":
                jerry.UserInfo();
                break;
            case "6":
                flag = false;
                break;
            default:
                jerry.Msg("Not a command! please see list of instructions!");
                break;
        }
    }
    catch (AlreadyExistsException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Debug.Fail(ex.Message);
    }
    catch (SyntaxException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Debug.Fail(ex.Message);
    }
    catch (BirthDateException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Debug.Fail(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Debug.Fail(ex.Message);
    }
    finally {
        Debug.Close();
    }
}