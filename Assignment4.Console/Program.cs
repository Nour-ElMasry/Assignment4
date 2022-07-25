using Assignment4.Domain;

var jerry = new ChatBot("Jerry", "I was created by Nour Eldin");
var flag = true;

jerry.instructions();
Console.WriteLine("\n///////////////////////////////////////////\n");
jerry.Intro();

while (flag)
{
    var input = jerry.chat();
    Console.WriteLine();
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